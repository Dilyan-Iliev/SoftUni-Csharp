using P._07_Military_Elite.Classes;
using P._07_Military_Elite.Enums;
using P._07_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;

namespace P._07_Military_Elite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new Dictionary<int, ISoldier>(); //ISoldier е най-абстрактното за всички интерфейси

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var objType = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];


                if (objType == "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    IPrivate @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(id, @private);
                }
                else if (objType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        int inputID = int.Parse(tokens[i]);
                        //ISoldier soldier = soldiers[inputID];
                        //lieutenantGeneral.Privates.Add(soldier as IPrivate);

                        IPrivate @private = soldiers[inputID] as IPrivate; //това е кастване
                        lieutenantGeneral.Privates.Add(@private);
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (objType == "Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    string corpType = tokens[5];
                    bool isValidEnum = Enum.TryParse<Corps>(corpType, out Corps result);

                    if (!isValidEnum)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string repairPart = tokens[i];
                        int repairHours = int.Parse(tokens[i + 1]);

                        IRepair repair = new Repair(repairPart, repairHours);

                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (objType == "Commando")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    string corpType = tokens[5];
                    bool isValidEnum = Enum.TryParse<Corps>(corpType, out Corps result);

                    if (!isValidEnum)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string missionCode = tokens[i];
                        string missionState = tokens[i + 1];

                        bool isValidMissionEnum = Enum.TryParse<MissionStatus>(missionState, out MissionStatus status);

                        if (!isValidMissionEnum)
                        {
                            continue;
                        }

                        IMission mission = new Mission(missionCode, status);
                        commando.Missions.Add(mission);
                    }

                    soldiers.Add(id, commando);
                }
                else if (objType == "Spy")
                {
                    int codeNumber = int.Parse(tokens[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
