using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercises
{
    class Program
    {
        public static void Main(string[] args)
        {
            //You can get the trainee details from the GetTraineeDetails() method in TraineeData class
             Menue();    
        }
        public static void Menue()
        {
            TraineeData traineeData=new TraineeData();
            List<TraineeDetails> traineeDetailsList=traineeData.GetTraineeDetails();
            System.Console.WriteLine("1. Press 1 to Show the list of Trainee Id 2.Press 2 to Show the first 3 Trainee Id using Take 3.Press 3 to show the last 2 Trainee Id using Skip");
            int menue= int.Parse(Console.ReadLine());
            switch(menue)
            {
                case 1:{
                    //Press 1 to Show the list of Trainee Id
                     var result=from trainee in traineeDetailsList
                                 select trainee.TraineeId;
                     foreach(var value in result)
                     {
                        System.Console.WriteLine(value);
                     }
                    break;
                }
                case 2:{
                    //Press 2 to Show the first 3 Trainee Id using Take
                    var result=from trainee in traineeDetailsList
                                 select trainee.TraineeId;
                    foreach(var data in result.Take(3))
                     {
                        System.Console.WriteLine(data);
                     }
                    break;
                }
                case 3:{
                    // Press 3 to show the last 2 Trainee Id using Skip
                    var result=from trainee in traineeDetailsList
                                 select trainee.TraineeId;
                    foreach(var data in result.Skip(3).Take(2))
                     {
                        System.Console.WriteLine(data);
                     }
                    break;
                }
                case 4:{
                    //Press 4 to show the count of Trainee
                    var result=traineeDetailsList.Count();
                    System.Console.WriteLine(result);
                    break;
                }
                case 5:{
                    //Press 5 to show the Trainee Name who are all passed out 2019 or later
                    var result=from trainee in traineeDetailsList
                                 where trainee.YearPassedOut>=2019
                                 select trainee.TraineeName;
                    foreach(var data in result)
                     {
                        System.Console.WriteLine(data);
                     }
                    break;
                }
                case 6:{
                    //Press 6 to show the Trainee Id and Trainee Name by alphabetic order of the trainee name.
                           var result=traineeDetailsList.OrderBy(trainee=>trainee.TraineeName);
                           foreach(var data in result)
                           {
                            System.Console.WriteLine(data.TraineeId+" - "+data.TraineeName);
                           }
             
                    break;
                }
                case 7:{
                    //Press 7 to show the Trainee Id, Trainee Name, Topic Name, Exercise Name and Mark who are all scores the more than or equal to 4 mark
                    var result =traineeDetailsList.SelectMany(trainee=>trainee.ScoreDetails.Where(trainees=> trainees.Mark>=4),
                               (trainee,trainees)=>new {trainee.TraineeId,trainee.TraineeName,trainees.TopicName,trainees.ExerciseName,trainees.Mark});
                       foreach(var data in result)
                           {
                        
                            System.Console.WriteLine(data);
                           }         

                    break;
                }
                case 8:{
                    //Press 8 to show the unique passed out year using distinct
                    
                    var result=traineeDetailsList.Select(trainee=>trainee.YearPassedOut).Distinct();
                     foreach(var data in result)
                           {
                        
                            System.Console.WriteLine(data);
                           }    
                    break;
                }
                case 9:{
                    //Press 9 to show the total marks of single user (get the Trainee Id from User), if Trainee Id does not exist, show the invalid message
                    
                    System.Console.WriteLine("Enter the trainee ID");
                    string traineeID=Console.ReadLine();
                    var trainee=traineeDetailsList.FirstOrDefault(trainee=>trainee.TraineeId==traineeID);
                    if(trainee!=null)
                    {
                        int totalScore=trainee.ScoreDetails.Sum(trainee=>trainee.Mark);
                        System.Console.WriteLine($"Total mark of trainee {traineeID} {totalScore}");
                    }
                    else{
                        System.Console.WriteLine("Invalid ID");
                    }
                    break;
                }
                case 10:{
                    // Press 10 to show the first Trainee Id and Trainee Name
                    var result=traineeDetailsList.First();
                    System.Console.WriteLine("ID "+result.TraineeId +" Name : " + result.TraineeName);
                    
                    break;
                }
                case 11:{
                    //Press 11 to show the last Trainee Id and Trainee Name
                    var result=traineeDetailsList.Last();
                    System.Console.WriteLine("ID "+result.TraineeId +" Name : " + result.TraineeName);
                    break;
                }
                case 12:{
                    //Press 12 to print the total score of each trainee
                    foreach(var trainee in traineeDetailsList)
                    {
                        int totalScore=trainee.ScoreDetails.Sum(score=>score.Mark);
                        System.Console.WriteLine("Training ID: "+trainee.TraineeId+": "+totalScore);
                    }
                    break;
                }
                case 13:{
                    //Press 13 to show the maximum total score
                    int maxScore=traineeDetailsList.Max(Score=>Score.ScoreDetails.Sum(add=> add.Mark));
                    System.Console.WriteLine("Maximum Mark: "+maxScore);
                    break;
                }
                case 14:{
                    //Press 14 to show the minimum total score
                    int minScore=traineeDetailsList.Min(Score=>Score.ScoreDetails.Sum(add=> add.Mark));
                    System.Console.WriteLine("Minimum Mark: "+minScore);
                    break;
                }
                case 15:{
                    //Press 15 to show the average of total score
                    double averageScore=traineeDetailsList.Average(Score=>Score.ScoreDetails.Sum(add=> add.Mark));
                    System.Console.WriteLine("Maximum Mark: "+averageScore);
                    break;
                }
                case 16:{
                    //Press 16 to show true or false if any one has the more than 40 score using any()
                    bool moreThan=traineeDetailsList.Any(more=>more.ScoreDetails.Sum(add=> add.Mark)>=40);
                    System.Console.WriteLine("Maximum Mark: "+moreThan);
                    break;
                }
                case 17:{
                    //Press 17 to show true of false if all of them has the more than 20 using all()
                    bool moreThan=traineeDetailsList.All(more=>more.ScoreDetails.Sum(add=> add.Mark)>=20);
                    System.Console.WriteLine("Maximum Mark: "+moreThan);
                    break;
                }
                case 18:{
                    // Press 18 to show the Trainee Id, Trainee Name, Topic Name, Exercise Name and Mark by show the Trainee Name as descending order and then show the Mark as descending order.
                    var result=traineeDetailsList.SelectMany(trainee=> trainee.ScoreDetails,(trainee,score)=>
                                        new {trainee.TraineeId,trainee.TraineeName,score.TopicName,score.ExerciseName,score.Mark})
                                        .OrderByDescending(trainee=>trainee.TraineeName).ThenByDescending(Score=>Score.Mark);

                    foreach(var data in result)
                    {
                        System.Console.WriteLine($"TraineeID:{data.TraineeId} TraineeName {data.TraineeName}  {data.TopicName}  {data.ExerciseName} {data.Mark}");
                    }
                    break;
                }
            }
        }
    }
}
