using Salary.Application.Commands;
using Salary.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverTimePolicies;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Salary.Application
{
    public class ImportEmployeeSalaryDto
    {
        public string Data { get; set; }
        public string OverTimeCalculator { get; set; }

        public CreateEmployeeSalaryCommand CreateEmployeeSalaryCommand(ImportDataFormatEnum dataType)
        {
            CreateEmployeeSalaryCommand command = null;

            switch (dataType) 
            {
                case ImportDataFormatEnum.Xml:
                    XmlSerializer serializer = new XmlSerializer(typeof(BaseCreateEmployeeSalaryCommand));
                    MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(Data));
                    var baseCreateEmployeeSalaryxml = (BaseCreateEmployeeSalaryCommand)serializer.Deserialize(memStream);
                    command = new CreateEmployeeSalaryCommand()
                    {
                        FirstName = baseCreateEmployeeSalaryxml.FirstName,
                        LastName = baseCreateEmployeeSalaryxml.LastName,
                        BaseSalary = baseCreateEmployeeSalaryxml.BaseSalary,
                        Allowance = baseCreateEmployeeSalaryxml.Allowance,
                        Transportation = baseCreateEmployeeSalaryxml.Transportation,
                        OverTimeCalculator = OverTimeCalculator,

                        TotalSalary = baseCreateEmployeeSalaryxml.BaseSalary
                                   + baseCreateEmployeeSalaryxml.Allowance
                                   + baseCreateEmployeeSalaryxml.Transportation
                                   + Calculate(OverTimeCalculator, baseCreateEmployeeSalaryxml.BaseSalary, baseCreateEmployeeSalaryxml.Allowance),
                    };

                    break;

                case ImportDataFormatEnum.Cs:
                    throw new NotImplementedException();
                    break;

                case ImportDataFormatEnum.Custom:
                    var result = Regex.Split(Data, "\r\n|\r|\n");
                    string[] words = result[1].Split('/');
                    command = new CreateEmployeeSalaryCommand()
                        {
                            FirstName = words[0],
                            LastName = words[1],
                            BaseSalary = long.Parse(words[2]),
                            Allowance = long.Parse(words[3]),
                            Transportation = long.Parse(words[4]),
                            OverTimeCalculator = OverTimeCalculator,

                            TotalSalary = long.Parse(words[2])
                            +long.Parse(words[3])
                            +long.Parse(words[4])
                            + Calculate(OverTimeCalculator, long.Parse(words[2]), long.Parse(words[3])),
                        };
                    break;

                default:
                    var baseCreateEmployeeSalaryJson = JsonConvert.DeserializeObject<BaseCreateEmployeeSalaryCommand>(Data);
                    command = new CreateEmployeeSalaryCommand()
                    { 
                        FirstName=baseCreateEmployeeSalaryJson.FirstName,
                        LastName=baseCreateEmployeeSalaryJson.LastName,
                        BaseSalary=baseCreateEmployeeSalaryJson.BaseSalary,
                        Allowance=baseCreateEmployeeSalaryJson.Allowance,
                        Transportation= baseCreateEmployeeSalaryJson.Transportation,
                        OverTimeCalculator = OverTimeCalculator,

                        TotalSalary = baseCreateEmployeeSalaryJson.BaseSalary
                                    + baseCreateEmployeeSalaryJson.Allowance
                                    + baseCreateEmployeeSalaryJson.Transportation
                                    + Calculate(OverTimeCalculator , baseCreateEmployeeSalaryJson.BaseSalary , baseCreateEmployeeSalaryJson.Allowance),
                    };
                   
                    break;
            }

            return command;
        }

        public long Calculate(string calculatore, long baseSalary, long allowance)
        {
            OverTimeEnum overTimePolicy = Enum.Parse<OverTimeEnum>(calculatore, true); // ignore cases 

            switch(overTimePolicy)
            {
                case OverTimeEnum.CalculatorA:
                    return baseSalary.CalculatorA(allowance);
                    //break;
                case OverTimeEnum.CalculatorB:
                    return baseSalary.CalculatorB(allowance);
                    //break;
                default:
                    return baseSalary.CalculatorC(allowance);
                    //break;
            }

            
        }
    }
}
