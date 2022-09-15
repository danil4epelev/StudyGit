using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace starkov.BotProcessing.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      CreateRoles();
    }
    
    public void CreateRoles()
    {
      var role = Sungero.Docflow.PublicInitializationFunctions.Module.CreateRole(Resources.ResponsibleForApplications,
                                                                                 Resources.DescriptionResponsibleForApplication,
                                                                                 Constants.Module.RoleResponsibleForApplications);
      if (role.IsSingleUser != true)
      {
        role.IsSingleUser = true;
        var administrator = Roles.Administrators.RecipientLinks.FirstOrDefault().Member;
        var row = role.RecipientLinks.AddNew();
        row.Member = administrator;       
        role.Save();
      }
      
    }
  }
}
