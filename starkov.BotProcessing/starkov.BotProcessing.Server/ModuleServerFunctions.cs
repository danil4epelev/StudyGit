using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace starkov.BotProcessing.Server
{
  public class ModuleFunctions
  {

    /// <summary>
    /// Создать простую задачу для ответственного за заявки 
    /// </summary>
    [Public(WebApiRequestType = RequestType.Post)]
    public void CreateTaskFromBotRequest(string textApplication, string buyerName, string buyerEmail, string buyerPhoneNumber)
    {
      var taskText = String.Format("Рассмотрите заявку от {0}, телефон: {1}, email: {2}. Текст заявки: {3}", buyerName, buyerPhoneNumber, buyerEmail, textApplication);
      var role = Roles.GetAll().Where(t => t.Sid == Constants.Module.RoleResponsibleForApplications).FirstOrDefault();
      
      if (role != null)
      {
        var task = Sungero.Workflow.SimpleTasks.Create(taskText, role);
        task.Start();
      }
      
    }

  }
}