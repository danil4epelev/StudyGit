using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;
using DirRX.Solution.ApprovalTask;

namespace DirRX.Solution.Server
{
  partial class ApprovalTaskRouteHandlers
  {

    public override void StartBlock5(Sungero.Docflow.Server.ApprovalReworkAssignmentArguments e)
    {
      base.StartBlock5(e);
    }

    public override void Script26Execute()
    {
      base.Script26Execute();
    }

    public override void StartBlock3(Sungero.Docflow.Server.ApprovalManagerAssignmentArguments e)
    {            
      e.Block.AbsoluteStopAssignmentsDeadline = Calendar.Now;
      
      e.Block.StopResult = Sungero.Docflow.ApprovalManagerAssignment.Result.Approved;
      
      base.StartBlock3(e);
    }

  }
}