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
                                newStatus = "Master Creation In Progress";
                                state = finalState;
                            }
                            else
                            {
                                //Master has been requested
                                newStatus = "Master Creation Requested";
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

                    case 6: //Looking at WORLot Release...........NOT NEEDED-DO SOMETHING WITH THIS AT SOME POINT!!!!!!

                        if (tempLots[0].WORLotReleased == 1)
                        {//WORLot Release is complete
                            state = 7;
                        }
                        else
                        {
                            //WORLot Release is not complete
                            state = 7;
                        }

                        break;

                    case 7:

                        if (tempLots[0].WORLotReleased == 1)
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

                        if (tempLots[0].TravelerReturned == 1)
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

                        if (tempLots[0].TravelerReleased == 1)
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
                            state = 2;
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

        //Dashboard Status Calculations----------------------------------------------------------------------------------------------
        public List<DatabaseTables.EngineeringDashboard> CalculateEngineeringDashboard(List<DatabaseTables.EngineeringDashboard> engineeringDashboard)
        {
            int state = 0;
            int finalState = 10;
            string newStatus = "";

            for (int i = 0; i < engineeringDashboard.Count(); i++)
            {   

                // Get BomValidationStatus
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check BOMValidationRequested
                            if (engineeringDashboard[i].BOMValidationRequest == "True")
                            {
                                //Bom Validation Requested, Check to see if BOMValidationInProgress
                                state = 1;
                            }
                            else
                            {
                                //Bom Validation Not Requested, Check to see if BOMValidationComplete
                                state = 2;
                            }

                            break;

                        case 1:
                            //Check to see if BOMValidationInProgress
                            if (engineeringDashboard[i].BOMValidationInProgress == "True")
                            {
                                //BOM Validation has been requested and is in progress - Check to see if Validation is Complete
                                state = 3;
                            }
                            else
                            {
                                //BOM Validation has been requested, but is not In Progress
                                state = finalState;
                                newStatus = "Requested";
                            }

                            break;

                        case 2:
                            //Check to see if BOMValidationComplete
                            if (engineeringDashboard[i].BOMValidationComplete == "True")
                            {
                                //BOM Validation is Complete
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Nothing has happened
                                state = finalState;
                                newStatus = "Not Started";
                            }

                            break;

                        case 3:
                            if (engineeringDashboard[i].BOMValidationComplete == "True")
                            {
                                //All 3 semaphores are true
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Only Requested and InProgress
                                state = finalState;
                                newStatus = "In Progress";
                            }

                            break;
                    }
                }

                engineeringDashboard[i].BOMValidationStatus = newStatus;


                //Get PreBid Status
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check PreBidRequested
                            if (engineeringDashboard[i].PreBidRequest == "True")
                            {
                                //PreBid Requested, Check to see if PreBidInProgress
                                state = 1;
                            }
                            else
                            {
                                //PreBid Not Requested, Check to see if PreBidComplete
                                state = 2;
                            }

                            break;

                        case 1:
                            //Check to see if PreBidInProgress
                            if (engineeringDashboard[i].PreBidInProgress == "True")
                            {
                                //PreBid has been requested and is in progress - Check to see if PreBid is Complete
                                state = 3;
                            }
                            else
                            {
                                //PreBid has been requested, but is not In Progress
                                state = finalState;
                                newStatus = "Requested";
                            }

                            break;

                        case 2:
                            //Check to see if PreBidComplete
                            if (engineeringDashboard[i].PreBidComplete == "True")
                            {
                                //PreBid is Complete
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Nothing has happened
                                state = finalState;
                                newStatus = "Not Started";
                            }

                            break;

                        case 3:
                            if (engineeringDashboard[i].PreBidComplete == "True")
                            {
                                //All 3 semaphores are true
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Only Requested and InProgress
                                state = finalState;
                                newStatus = "In Progress";
                            }

                            break;
                    }
                }

                engineeringDashboard[i].PreBidStatus = newStatus;

                //Get Quote Review Status
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check QuoteReviewRequested
                            if (engineeringDashboard[i].QuoteReviewRequest == "True")
                            {
                                //QuoteReview Requested, Check to see if QuoteReviewInProgress
                                state = 1;
                            }
                            else
                            {
                                //QuoteReview Not Requested, Check to see if QuoteReviewComplete
                                state = 2;
                            }

                            break;

                        case 1:
                            //Check to see if QuoteReviewInProgress
                            if (engineeringDashboard[i].QuoteReviewInProgress == "True")
                            {
                                //QuoteReview has been requested and is in progress - Check to see if QuoteReview is Complete
                                state = 3;
                            }
                            else
                            {
                                //QuoteReview has been requested, but is not In Progress
                                state = finalState;
                                newStatus = "Requested";
                            }

                            break;

                        case 2:
                            //Check to see if QuoteReviewComplete
                            if (engineeringDashboard[i].QuoteReviewComplete == "True")
                            {
                                //PreBid is Complete
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Nothing has happened
                                state = finalState;
                                newStatus = "Not Started";
                            }

                            break;

                        case 3:
                            if (engineeringDashboard[i].QuoteReviewComplete == "True")
                            {
                                //All 3 semaphores are true
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Only Requested and InProgress
                                state = finalState;
                                newStatus = "In Progress";
                            }

                            break;
                    }
                }

                engineeringDashboard[i].QuoteReviewStatus = newStatus;

                //Get Master Status
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check MasterRequested
                            if (engineeringDashboard[i].MasterRequest == "True")
                            {
                                //Master Requested, Check to see if MasterInProgress
                                state = 1;
                            }
                            else
                            {
                                //Master Not Requested, Check to see if MasterComplete
                                state = 2;
                            }

                            break;

                        case 1:
                            //Check to see if MasterInProgress
                            if (engineeringDashboard[i].MasterInProgress == "True")
                            {
                                //Master has been requested and is in progress - Check to see if Master is Complete
                                state = 3;
                            }
                            else
                            {
                                //Master has been requested, but is not In Progress
                                state = finalState;
                                newStatus = "Requested";
                            }

                            break;

                        case 2:
                            //Check to see if MasterComplete
                            if (engineeringDashboard[i].MasterComplete == "True")
                            {
                                //PreBid is Complete
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Nothing has happened
                                state = finalState;
                                newStatus = "Not Started";
                            }

                            break;

                        case 3:
                            if (engineeringDashboard[i].MasterComplete == "True")
                            {
                                //All 3 semaphores are true
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Only Requested and InProgress
                                state = finalState;
                                newStatus = "In Progress";
                            }

                            break;
                    }
                }

                engineeringDashboard[i].MasterStatus = newStatus;

                //Get MasterReview Status
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check MasterReviewRequested
                            if (engineeringDashboard[i].MasterReviewRequest == "True")
                            {
                                //MasterReview Requested, Check to see if MasterReviewInProgress
                                state = 1;
                            }
                            else
                            {
                                //MasterReview Not Requested, Check to see if MasterReviewComplete
                                state = 2;
                            }

                            break;

                        case 1:
                            //Check to see if MasterReviewInProgress
                            if (engineeringDashboard[i].MasterReviewInProgress == "True")
                            {
                                //MasterReview has been requested and is in progress - Check to see if MasterReview is Complete
                                state = 3;
                            }
                            else
                            {
                                //MasterReview has been requested, but is not In Progress
                                state = finalState;
                                newStatus = "Requested";
                            }

                            break;

                        case 2:
                            //Check to see if MasterReviewComplete
                            if (engineeringDashboard[i].MasterReviewComplete == "True")
                            {
                                //PreBid is Complete
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Nothing has happened
                                state = finalState;
                                newStatus = "Not Started";
                            }

                            break;

                        case 3:
                            if (engineeringDashboard[i].MasterReviewComplete == "True")
                            {
                                //All 3 semaphores are true
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Only Requested and InProgress
                                state = finalState;
                                newStatus = "In Progress";
                            }

                            break;
                    }
                }

                engineeringDashboard[i].MasterReviewStatus = newStatus;

                //Determine whether or not this is a Quote or WOR and fill in cells as necessary
                if (engineeringDashboard[i].QuoteOrWOR == "Quote")
                {
                    //Fill in "Not Used" for all non-used cells
                    engineeringDashboard[i].QuoteReviewRequest = "Not Used";
                    engineeringDashboard[i].QuoteReviewInProgress = "Not Used";
                    engineeringDashboard[i].QuoteReviewComplete = "Not Used";
                    engineeringDashboard[i].QuoteReviewStatus = "Not Used";

                    engineeringDashboard[i].MasterRequest = "Not Used";
                    engineeringDashboard[i].MasterInProgress = "Not Used";
                    engineeringDashboard[i].MasterComplete = "Not Used";
                    engineeringDashboard[i].MasterStatus = "Not Used";

                    engineeringDashboard[i].MasterReviewRequest = "Not Used";
                    engineeringDashboard[i].MasterReviewInProgress = "Not Used";
                    engineeringDashboard[i].MasterReviewComplete = "Not Used";
                    engineeringDashboard[i].MasterReviewStatus = "Not Used";

                    engineeringDashboard[i].WORLotReleased = "Not Used";
                    engineeringDashboard[i].TravelerReleased = "Not Used";
                    engineeringDashboard[i].StencilPlotsApproved = "Not Used";
                    engineeringDashboard[i].PCBArraysApproved = "Not Used";
                    engineeringDashboard[i].KitReleased = "Not Used";
                }
            }


            //Send back the updated engineeringDashboard
            return engineeringDashboard;

        }

        //Purchasing Dashboard Status Calculations----------------------------------------------------------------------------------------------
        public List<DatabaseTables.PurchasingDashboard> CalculatePurchasingDashboard(List<DatabaseTables.PurchasingDashboard> purchasingDashboard)
        {
            int state = 0;
            int finalState = 10;
            string newStatus = "";

            for (int i = 0; i < purchasingDashboard.Count(); i++)
            {

                // Get PartsReviewStatus
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check PartsReviewRequest
                            if (purchasingDashboard[i].PartsReviewRequest == "True")
                            {
                                //PartsReview Requested, Check to see if PartsReviewInProgress
                                state = 1;
                            }
                            else
                            {
                                //PartsReview Not Requested, Check to see if PartsReviewComplete
                                state = 2;
                            }

                            break;

                        case 1:
                            //Check to see if PartsReviewInProgress
                            if (purchasingDashboard[i].PartsReviewInProgress == "True")
                            {
                                //PartsReview has been requested and is in progress - Check to see if Review is Complete
                                state = 3;
                            }
                            else
                            {
                                //PartsReview has been requested, but is not In Progress
                                state = finalState;
                                newStatus = "Requested";
                            }

                            break;

                        case 2:
                            //Check to see if PartsReviewComplete
                            if (purchasingDashboard[i].PartsReviewComplete == "True")
                            {
                                //BOM Validation is Complete
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Nothing has happened
                                state = finalState;
                                newStatus = "Not Started";
                            }

                            break;

                        case 3:
                            if (purchasingDashboard[i].PartsReviewComplete == "True")
                            {
                                //All 3 semaphores are true
                                state = finalState;
                                newStatus = "Complete";
                            }
                            else
                            {
                                //Only Requested and InProgress
                                state = finalState;
                                newStatus = "In Progress";
                            }

                            break;
                    }
                }

                purchasingDashboard[i].PartsReviewStatus = newStatus;

                // Get StencilStatus
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check to see if Stencils are Required
                            if (purchasingDashboard[i].StencilsRequired == "True")
                            {
                                //Stencils are required - Check to see if they have been ordered
                                state = 1;
                            }
                            else
                            {
                                //Stencil order not required - Check to see if we already have some
                                state = 3;
                                
                            }

                            break;

                        case 1:
                            if (purchasingDashboard[i].StencilsOrdered == "True")
                            {
                                //Stencils have been ordered - Check to see if they have been received
                                state = 2;

                            }
                            else
                            {
                                //Not Ordered Yet
                                state = finalState;
                                newStatus = "Stencils Needed";
                            }

                            break;

                        case 2:
                            if (purchasingDashboard[i].StencilsReceived == "True")
                            {
                                //Stencils have been received
                                state = finalState;
                                newStatus = "Stencils Received";
                            }
                            else
                            {
                                //Stencils have not been received
                                state = finalState;
                                newStatus = "Stencils on Order";
                            }

                            break;

                        case 3:
                            if (purchasingDashboard[i].StencilsReceived == "True")
                            {
                                state = finalState;
                                newStatus = "Stencils Received";
                            }
                            else
                            {
                                state = finalState;
                                newStatus = "Not Used";
                            }
                                break;
                    }
                }

                purchasingDashboard[i].StencilStatus = newStatus;

                // Get PCBStatus
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check to see if PCBs are Required
                            if (purchasingDashboard[i].PCBRequired == "True")
                            {
                                //PCBs are required - Check to see if they have been ordered
                                state = 1;
                            }
                            else
                            {
                                //PCB order not required - Check to see if we already have some
                                state = 3;

                            }

                            break;

                        case 1:
                            if (purchasingDashboard[i].PCBOrdered == "True")
                            {
                                //PCBs have been ordered - Check to see if they have been received
                                state = 2;

                            }
                            else
                            {
                                //Not Ordered Yet
                                state = finalState;
                                newStatus = "PCBs Needed";
                            }

                            break;

                        case 2:
                            if (purchasingDashboard[i].PCBReceived == "True")
                            {
                                //PCBs have been received
                                state = finalState;
                                newStatus = "PCBs Received";
                            }
                            else
                            {
                                //PCBs have not been received
                                state = finalState;
                                newStatus = "PCBs on Order";
                            }

                            break;

                        case 3:
                            if (purchasingDashboard[i].PCBReceived == "True")
                            {
                                state = finalState;
                                newStatus = "PCBs Received";
                            }
                            else
                            {
                                state = finalState;
                                newStatus = "Not Used";
                            }
                            break;
                    }
                }

                purchasingDashboard[i].PCBStatus = newStatus;

                // Get Parts Status
                state = 0;
                newStatus = "";

                while (state < finalState)
                {
                    switch (state)
                    {
                        case 0:
                            //Check to see if Parts are Required
                            if (purchasingDashboard[i].PartsRequired == "True")
                            {
                                //Parts are required - Check to see if they have been ordered
                                state = 1;
                            }
                            else
                            {
                                //Parts order not required - Check to see if we already have some
                                state = 3;

                            }

                            break;

                        case 1:
                            if (purchasingDashboard[i].PartsOrdered == "True")
                            {
                                //Parts have been ordered - Check to see if they have been received
                                state = 2;

                            }
                            else
                            {
                                //Not Ordered Yet
                                state = finalState;
                                newStatus = "Parts Needed";
                            }

                            break;

                        case 2:
                            if (purchasingDashboard[i].PartsReceived == "True")
                            {
                                //Parts have been received
                                state = finalState;
                                newStatus = "Parts Received";
                            }
                            else
                            {
                                //Parts have not been received
                                state = finalState;
                                newStatus = "Parts on Order";
                            }

                            break;

                        case 3:
                            if (purchasingDashboard[i].PartsReceived == "True")
                            {
                                state = finalState;
                                newStatus = "Parts Received";
                            }
                            else
                            {
                                state = finalState;
                                newStatus = "Not Used";
                            }
                            break;
                    }
                }

                purchasingDashboard[i].PartsStatus = newStatus;


                //Determine whether or not this is a Quote or WOR and fill in cells as necessary
                if (purchasingDashboard[i].QuoteOrWOR == "Quote")
                {
                    //Fill in "Not Used" for all non-used cells if it is a quote

                    purchasingDashboard[i].StencilsRequired = "Not Used";
                    purchasingDashboard[i].StencilsOrdered = "Not Used";
                    purchasingDashboard[i].StencilsReceived = "Not Used";
                    purchasingDashboard[i].StencilStatus = "Not Used";

                    purchasingDashboard[i].PCBRequired = "Not Used";
                    purchasingDashboard[i].PCBOrdered = "Not Used";
                    purchasingDashboard[i].PCBReceived = "Not Used";
                    purchasingDashboard[i].PCBStatus = "Not Used";

                    purchasingDashboard[i].PartsOrdered = "Not Used";
                    purchasingDashboard[i].PartsReceived = "Not Used";
                    purchasingDashboard[i].PartsStatus = "Not Used";
                    purchasingDashboard[i].KitReleased = "Not Used";
                }
                else
                {   //WOR
                    purchasingDashboard[i].PartsReviewRequest = "Not Used";
                    purchasingDashboard[i].PartsReviewInProgress = "Not Used";
                    purchasingDashboard[i].PartsReviewComplete = "Not Used";
                    purchasingDashboard[i].PartsReviewStatus = "Not Used";
                }
            }

            //Send it back!
            return purchasingDashboard;
        }


    }
}
