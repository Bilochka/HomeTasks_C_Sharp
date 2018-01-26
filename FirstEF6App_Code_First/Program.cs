﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace FirstEF6App_Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            using (SoccerContext context = new SoccerContext())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Обрати: перегляд таблиць - 1 ; CRUD операції - 2 ");
                string choiceStr = Console.ReadLine();
                int choice = Convert.ToInt32(choiceStr);

                if (choice == 1)
                {
                    Console.WriteLine("Обрати: Players Table - 1 ; Teams Table - 2, Players and Teams Table - 3 ");
                    string choiceTableStr = Console.ReadLine();
                    int choiceTable = Convert.ToInt32(choiceTableStr);
                    switch (choiceTable)
                    {
                        case 1:
                            foreach (var player in context.Players)
                            {
                                Console.WriteLine($"Id: {player.Id}" +
                                                  $"FirstName: {player.FirstName}" +
                                                  $"LastName: {player.LastName}" +
                                                  $"PlayerNumber: {player.PlayerNumber}" +
                                                  $"Age: {player.Age}" +
                                                  $"TeamId: {player.TeamId}");
                                Console.WriteLine(new string('-', 20));
                            }
                            break;
                        case 2:
                            foreach (var team in context.Teams)
                            {
                                Console.WriteLine($"Id: {team.Id}" +
                                                  $"Name: {team.Name}" +
                                                  $"Coach: {team.Coach}" );
                                Console.WriteLine(new string('-', 20));
                            }
                            break;
                        case 3:
                            foreach (var player in context.Players)
                            {
                                Console.WriteLine($"Id: {player.Id}" +
                                                  $"FirstName: {player.FirstName}" +
                                                  $"LastName: {player.LastName}" +
                                                  $"PlayerNumber: {player.PlayerNumber}" +
                                                  $"Age: {player.Age}" +
                                                  $"TeamId: {player.TeamId}");

                                foreach (var team in context.Teams)
                                {
                                    if (player.TeamId == team.Id)
                                    {
                                        Console.WriteLine($"Name: {team.Name}" +
                                                          $"Coach: {team.Coach}");
                                        Console.WriteLine(new string('-', 20));
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong number");
                            break;
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine(
                        "Оберіть операцію: Create player- 1, Create team- 2, Update player- 3, Update team- 4, Delete player- 5 Delete team- 6");
                    string operationStr = Console.ReadLine();
                    int choiceOperation = Convert.ToInt32(operationStr);

                    switch (choiceOperation)
                    {
                        case 1:
                            Console.WriteLine("Enter FirstName");
                            string FirstName1 = Console.ReadLine();
                            Console.WriteLine("Enter LastName");
                            string LastName1 = Console.ReadLine();
                            Console.WriteLine("Enter PlayerNumber");
                            string PlayerNumberStr = Console.ReadLine();
                            int PlayerNumber1 = Convert.ToInt32(PlayerNumberStr);
                            Console.WriteLine("Enter Age");
                            string AgeStr = Console.ReadLine();
                            int Age1 = Convert.ToInt32(AgeStr);
                            Console.WriteLine("Enter TeamId");
                            string TeamIdStr = Console.ReadLine();
                            int TeamId1 = Convert.ToInt32(TeamIdStr);

                            Player pl = new Player()
                            {
                                Id = Guid.NewGuid(),
                                FirstName = FirstName1,
                                LastName = LastName1,
                                PlayerNumber = PlayerNumber1,
                                Age = Age1,
                                TeamId = TeamId1
                            };
                            context.Players.Add(pl);
                            context.SaveChanges();
                            Console.WriteLine("Объекты успешно сохранены");
                            //////////////////////////////////
                            foreach (var player in context.Players)
                            {
                                Console.WriteLine($"Id: {player.Id}" +
                                                  $"FirstName: {player.FirstName}" +
                                                  $"LastName: {player.LastName}" +
                                                  $"PlayerNumber: {player.PlayerNumber}" +
                                                  $"Age: {player.Age}" +
                                                  $"TeamId: {player.TeamId}");
                                Console.WriteLine(new string('-', 20));
                            }
                            
                            ///////////////////////////////////

                            break;
                        case 2:
                            Console.WriteLine("Enter Name");
                            string Name1 = Console.ReadLine();
                            Console.WriteLine("Enter Coach");
                            string Coach1 = Console.ReadLine();
                            context.Teams.Add(new Team()
                            {
                                Id = i,
                                Name = Name1,
                                Coach = Coach1
                            });
                            context.SaveChanges();
                            i++;
                            break;
                        case 3:
                            Console.WriteLine("Enter player Id");
                            string upDateplayerIdStr = Console.ReadLine();
                            foreach (var player in context.Players)
                            {
                                string strId = Convert.ToString(player.Id);
                                if (upDateplayerIdStr == strId)
                                {
                                    Console.WriteLine("Enter FirstName");
                                    string FirstName2 = Console.ReadLine();
                                    Console.WriteLine("Enter LastName");
                                    string LastName2 = Console.ReadLine();
                                    Console.WriteLine("Enter PlayerNumber");
                                    string PlayerNumberStr2 = Console.ReadLine();
                                    int PlayerNumber2 = Convert.ToInt32(PlayerNumberStr2);
                                    Console.WriteLine("Enter Age");
                                    string AgeStr2 = Console.ReadLine();
                                    int Age2 = Convert.ToInt32(AgeStr2);
                                    Console.WriteLine("Enter TeamId");
                                    string TeamIdStr2 = Console.ReadLine();
                                    int TeamId2 = Convert.ToInt32(TeamIdStr2);
                                    context.Players.Add(new Player()
                                    {
                                        Id = player.Id,
                                        FirstName = FirstName2 ,
                                        LastName = LastName2,
                                        PlayerNumber = PlayerNumber2,
                                        Age = Age2,
                                        TeamId = TeamId2
                                    });
                                    context.SaveChanges();
                                    Console.WriteLine("Update is fixed");
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter team Id");
                            string upDateTeamIdStr = Console.ReadLine();
                            int upDateTeamId = Convert.ToInt32(upDateTeamIdStr);
                            foreach (var team in context.Teams)
                            {if (upDateTeamId == team.Id)
                                {
                                    Console.WriteLine("Enter Name");
                                    string Name2 = Console.ReadLine();
                                    Console.WriteLine("Enter Coach");
                                    string Coach2 = Console.ReadLine();
                                    context.Teams.Add(new Team()
                                    {
                                        Id = team.Id,
                                        Name = Name2,
                                        Coach = Coach2
                                    });
                                    context.SaveChanges();
                                    Console.WriteLine("Update is fixed");
                                }
                            }
                            break;
                        case 5:
                            Console.WriteLine("Enter player Id");
                            string deleteplayerIdStr = Console.ReadLine();
                            foreach (var player in context.Players)
                            {
                                string strId = Convert.ToString(player.Id);
                                if (deleteplayerIdStr == strId)
                                {
                                    context.Players.Remove(player);
                                    context.SaveChanges();
                                }
                            }
                            break;
                        case 6:
                            Console.WriteLine("Enter team Id");
                            string deleteTeamIdIdStr = Console.ReadLine();
                            int deleteTeamId = Convert.ToInt32(deleteTeamIdIdStr);
                            foreach (var team in context.Teams)
                            {
                                if (deleteTeamId == team.Id)
                                {
                                    context.Teams.Remove(team);
                                    context.SaveChanges();
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong number");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong number");
                }
            }
            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();
        }
    }
}