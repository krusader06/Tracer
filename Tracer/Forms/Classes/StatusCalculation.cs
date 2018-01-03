using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes
{
    public class StatusCalculation
    {
        public void CalculateStatus(Classes.LotTask currentTask)
        {   //Find out whether or not the task is a Quote Task or Lot Task
            if (currentTask.Lot == 0) //The lot will be 0 if it is still in the quoting stage...
            {
                CalculateQuoteStatus(currentTask);
            }
            else
            {
                CalculateLotStatus(currentTask);
            }
        }


        public void CalculateLotStatus(Classes.LotTask currentTask)
        {
            //Holder for the LotStatus
            List<DatabaseTables.LotStatus> tempLots = new List<DatabaseTables.LotStatus>();
            List<string> LotID = new List<string>();
            //This is responsible for going through a WOR/Lot and updating the "JobStatus" field on LotStatus Table.

            //1. Get LotID for the WOR/Lot combo
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot='{ currentTask.Lot }'").ToList();

                //2. Load a new LotStatus where LotID = previously found LotID
                tempLots = connection.Query<DatabaseTables.LotStatus>($"SELECT * FROM LotStatus WHERE LotID='{ LotID[0] }'").ToList();
            }



            //Parse the LotStatus

            int state = 0;
            int finalState = 15;
            var newStatus = "";

            //For each step (Quote Review, Master, Master Review) it first looks to see if the step is complete.
            //If it is complete, it moves on to the next step
            //if not complete, it looks to see if it's been requested
            //if it is requested, then it looks to see if it's In Progress

            while (state < finalState)
            {
                switch (state)
                {
                    case 0: //Looking at Quote Review Status

                        if (tempLots[0].QuoteReviewComplete == 1)
                        {//Quote Review is complete, Go on to check for Master Status
                            state = 2;
                        }else
                        {
                            //Quote Review is not complete
                            state = 1;
                        }

                        if (tempLots[0].SuperHot == 1)
                        {
                            //SuperHot is Set
                            newStatus = "Super Hot Job!";
                            state = finalState;
                        }

                        break;

                    case 1:

                        if (tempLots[0].QuoteReviewRequest == 1)
                        {
                            //Quote Review has been requested, check to see if it is in progress
                            if (tempLots[0].QuoteReviewInProgress == 1)
                            {
                                //Quote Review is in Progress, Update newStatus and signal end of state machine
                                newStatus = "Quote Review In Progress";
                                state = finalState;
                            } else
                            {
                                //Quote Review has been requested
                                newStatus = "Quote Review Requested";
                                state = finalState;
                            }
                        }
                        else
                        {
                            //Quote Review has not been requested
                            newStatus = "New Work Order";
                            state = finalState;
                        }

                        break;

                    case 2: //Looking at Master

                        if (tempLots[0].MasterComplete == 1)
                        {//Master is complete, Go on to check for Master Status
                            state = 4;
                        }
                        else
                        {
                            //Master is not complete
                            state = 3;
                        }

                        break;

                    case 3:

                        if (tempLots[0].MasterRequest == 1)
                        {
                            //Master has been requested, check to see if it is in progress
                            if (tempLots[0].MasterInProgress == 1)
                            {
                                //Master is in Progress, Update newStatus and signal end of state machine
                                newStatus = "Master In Progress";
                                state = finalState;
                            }
                            else
                            {
                                //Master has been requested
                                newStatus = "Master Requested";
                                state = finalState;
                            }
                        }
                        else
                        {
                            //Master has not been requested
                            newStatus = "Quote Review Complete";
                            state = finalState;
                        }

                        break;

                    case 4: //Looking at Master Review

                        if (tempLots[0].MasterReviewComplete == 1)
                        {//Master Review is complete, Go on to check for Master Status
                            state = 6;
                        }
                        else
                        {
                            //Master Review is not complete
                            state = 5;
                        }

                        break;

                    case 5:

                        if (tempLots[0].MasterReviewRequest == 1)
                        {
                            //Master Review has been requested, check to see if it is in progress
                            if (tempLots[0].MasterReviewInProgress == 1)
                            {
                                //Master Review is in Progress, Update newStatus and signal end of state machine
                                newStatus = "Master Review In Progress";
                                state = finalState;
                            }
                            else
                            {
                                //Master Review has been requested
                                newStatus = "Master Review Requested";
                                state = finalState;
                            }
                        }
                        else
                        {
                            //Master Review has not been requested
                            newStatus = "Master Complete";
                            state = finalState;
                        }

                        break;

                    case 6: //Looking at WORLot Release

                        if (tempLots[0].WORLotReleaseComplete == 1)
                        {//WORLot Release is complete
                            state = 8;
                        }
                        else
                        {
                            //WORLot Release is not complete
                            state = 7;
                        }

                        break;

                    case 7:

                        if (tempLots[0].WORLotReleaseInProgress == 1)
                        {

                            //WORLot Release is in Progress, Update newStatus and signal end of state machine
                            newStatus = "Work Order Release In Progress";
                            state = finalState;

                        }
                        else
                        {
                            //WORLot Release has not been requested
                            newStatus = "Master Review Complete";
                            state = finalState;
                        }

                        break;

                    case 8: //Looking at Traveler Status

                        if (tempLots[0].TravelerComplete == 1)
                        {//Traveler is complete
                            state = 10;
                        }
                        else
                        {
                            //Traveler is not complete
                            state = 9;
                        }

                        break;

                    case 9:

                        if (tempLots[0].TravelerInProgress == 1)
                        {

                            //Traveler is in Progress, Update newStatus and signal end of state machine
                            newStatus = "Traveler is In Progress";
                            state = finalState;

                        }
                        else
                        {
                            //WORLot Release has not been requested
                            newStatus = "Traveler Complete";
                            state = finalState;
                        }

                        break;

                    case 10: //Looking at Job Progress

                        if (tempLots[0].JobComplete == 1)
                        {//Job is complete
                            newStatus = "Job Complete";
                            state = finalState;
                        }

                        break;

                    default:

                        newStatus = "Unknown State";
                        state = finalState;

                        break;
                }
            }


            //Write newStatus to LotStatus.JobStatus
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                connection.Execute($"UPDATE LotStatus SET JobStatus='{ newStatus }' WHERE LotID='{ LotID[0] }'");
            }
        }




        public void CalculateQuoteStatus(Classes.LotTask currentTask)
        {

            //Holder for the QuoteStatus
            List<DatabaseTables.QuoteStatus> tempLots = new List<DatabaseTables.QuoteStatus>();
            //This is responsible for going through a QuoteWOR and updating the "QuoteCurrentStatus" field on QuoteStatus Table.

            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //Load a new QuoteCurrentStatus where QuoteWOR = currentTask.JobWOR
                tempLots = connection.Query<DatabaseTables.QuoteStatus>($"SELECT * FROM QuoteStatus WHERE QuoteWOR='{ currentTask.JobWOR }'").ToList();
            }

            //Parse the QuoteStatus

            int state = 0;
            int finalState = 15;
            var newStatus = "";

            //For each step (BOMValidation, PartsReview, PreBid, and FinalReview) it first looks to see if the step is complete.
            //If it is complete, it moves on to the next step
            //if not complete, it looks to see if it's been requested
            //if it is requested, then it looks to see if it's In Progress


            while (state < finalState)
            {
                switch (state)
                {
                    case 0: //Looking at BOM Validation Status

                        if (tempLots[0].BOMValidationComplete == 1)
                        {//BOM Validation is complete, Go on to check for Parts Review Status
                            state = 2;

                            newStatus = "BOM Validation is Complete";
                        }
                        else
                        {
                            //BOM Validation is not complete
                            state = 1;
                        }

                        break;

                    case 1:

                        if (tempLots[0].BOMValidationRequest == 1)
                        {
                            //BOM Validation has been requested, check to see if it is in progress
                            if (tempLots[0].BOMValidationInProgress == 1)
                            {
                                //BOM Validation is in Progress, Update newStatus and signal end of state machine
                                newStatus = "BOM Validation In Progress";
                                state = finalState;
                            }
                            else
                            {
                                //BOM Validation has been requested
                                newStatus = "BOM Validation Requested";
                                state = finalState;
                            }
                        }
                        else
                        {
                            //BOM Validation has not been requested, check to see if Parts Review has been Requested
                            newStatus = "New Quote";
                        }

                        break;

                    case 2: //Looking at Parts Review

                        if (tempLots[0].PartsReviewComplete == 1)
                        {//Parts Review is complete, Go on to check for Pre-Bid Status
                            state = 4;
                            newStatus = "Parts Review Complete";
                        }
                        else
                        {
                            //Parts Review is not complete
                            state = 3;
                        }

                        break;

                    case 3:

                        if (tempLots[0].PartsReviewRequest == 1)
                        {
                            //Parts Review has been requested, check to see if it is in progress
                            if (tempLots[0].PartsReviewInProgress == 1)
                            {
                                //Parts Review is in Progress, Update newStatus and signal end of state machine
                                newStatus = "Parts Review In Progress";
                                state = finalState;
                            }
                            else
                            {
                                //Parts Review has been requested
                                newStatus = "Parts Review Requested";
                                state = finalState;
                            }
                        }
                        else
                        {
                            //Parts Review has not been requested, Check to see if Pre-Bid has been requested
                            state = 4; //This is a difference from the above state machine becuase Parts Review might not come before Pre-Bid
                        }

                        break;

                    case 4: //Looking at Pre-Bid Review

                        if (tempLots[0].PreBidComplete == 1)
                        {//Pre-Bid Review is complete, Go on to check for Final Review Status
                            state = 6;
                            newStatus = "Pre-Bid Review Complete";
                        }
                        else
                        {
                            //Pre-Bid Review is not complete
                            state = 5;
                        }

                        break;

                    case 5:

                        if (tempLots[0].PreBidRequest == 1)
                        {
                            //Pre-Bid Review has been requested, check to see if it is in progress
                            if (tempLots[0].PreBidInProgress == 1)
                            {
                                //Pre-Bid Review is in Progress, Update newStatus and signal end of state machine
                                newStatus = "Pre-Bid Review In Progress";
                                state = finalState;
                            }
                            else
                            {
                                //Pre-Bid Review has been requested
                                newStatus = "Pre-Bid Review Requested";
                                state = finalState;
                            }
                        }
                        else
                        {
                            //Pre-Bid Review has not been requested
                            state = finalState;
                        }

                        break;

                    case 6: //Looking at Final Review

                        if (tempLots[0].FinalReviewComplete == 1)
                        {//Final Review is complete
                            state = 8;
                        }
                        else
                        {
                            //Final Review is not complete
                            state = 7;
                        }

                        break;

                    case 7:

                        if (tempLots[0].FinalReviewInProgress == 1)
                        {

                            //Final Review is in Progress, Update newStatus and signal end of state machine
                            newStatus = "Final Review In Progress";
                            state = finalState;

                        }
                        else
                        {
                            //Final Review has not been requested
                            newStatus = "Final Review Complete";
                            state = finalState;
                        }

                        break;

                    default:

                        newStatus = "Unknown State";
                        state = finalState;

                        break;
                }
            }


            //Write newStatus to QuteStatus.QWuoteCurrentStatus
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                connection.Execute($"UPDATE QuoteStatus SET QuoteCurrentStatus='{ newStatus }' WHERE QuoteWOR='{ currentTask.JobWOR }'");
            }





        }


    }
}
