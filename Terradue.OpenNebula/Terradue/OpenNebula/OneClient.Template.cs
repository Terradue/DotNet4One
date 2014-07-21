using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public partial class OneClient {

        /// <summary>
        /// Allocates the template.
        /// </summary>
        /// <returns>The template ID.</returns>
        /// <param name="content">Content.</param>
        public int TemplateAllocate(string content){
            int result = 0;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateAllocate(this.SessionSHA, content);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Clones the template.
        /// </summary>
        /// <returns><c>true</c>, if template was cloned, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier of the template to clone.</param>
        /// <param name="name">Name of the new template.</param>
        public int TemplateClone(int id, string name){
            int result = 0;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateClone(this.SessionSHA, id, name);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the template.
        /// </summary>
        /// <returns><c>true</c>, if template was deleted, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier of the template.</param>
        public bool TemplateDelete(int id){
            bool result = false;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateDelete(this.SessionSHA, id);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Instanciates the VM from template.
        /// </summary>
        /// <returns>The new VM id</returns>
        /// <param name="id">Identifier of the template.</param>
        /// <param name="templateName">New VM name.</param>
        public int TemplateInstanciateVM(int id, string vmName){
            int result = 0;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateInstantiate(this.SessionSHA, id, vmName);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Renames the template.
        /// </summary>
        /// <returns><c>true</c>, if template was renamed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newName">New name.</param>
        public bool TemplateRename(int id, string newName){
            bool result = false;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateRename(this.SessionSHA, id, newName);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Updates the template.
        /// </summary>
        /// <returns><c>true</c>, if template was updated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newContent">New content.</param>
        public bool TemplateUpdate(int id, string newContent){
            bool result = false;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateUpdate(this.SessionSHA, id, newContent);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Change permissions of the template
        /// </summary>
        /// <returns><c>true</c>, if chmod was templated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="userUse">User use.</param>
        /// <param name="userManage">User manage.</param>
        /// <param name="userAdmin">User admin.</param>
        /// <param name="groupUse">Group use.</param>
        /// <param name="groupManage">Group manage.</param>
        /// <param name="groupAdmin">Group admin.</param>
        /// <param name="otherUse">Other use.</param>
        /// <param name="otherManage">Other manage.</param>
        /// <param name="otherAdmin">Other admin.</param>
        public bool TemplateChmod(int id, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin){
            bool result = false;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateChangeMod(this.SessionSHA, id, userUse, userManage, userAdmin, groupUse, groupManage, groupAdmin, otherUse, otherManage, otherAdmin);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Changes the template owner.
        /// </summary>
        /// <returns><c>true</c>, if template owner was changed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="usrId">Usr identifier.</param>
        /// <param name="grpId">Group identifier.</param>
        public bool TemplateChangeOwner(int id, int usrId, int grpId){
            bool result = false;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateChangeOwner(this.SessionSHA, id, usrId, grpId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the template info.
        /// </summary>
        /// <returns><c>true</c>, if template info was gotten, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        public VMTEMPLATE TemplateGetInfo(int id){
            VMTEMPLATE result = null;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplateInfo(this.SessionSHA, id);
            result = (VMTEMPLATE)Deserialize(typeof(VMTEMPLATE), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the template list info.
        /// </summary>
        /// <returns>The template list info.</returns>
        /// <param name="templateFilterFlag">Template filter flag.</param>
        /// <param name="rangeStartId">Range start identifier.</param>
        /// <param name="rangeEndId">Range end identifier.</param>
        public VMTEMPLATE_POOL TemplateGetPoolInfo(int templateFilterFlag, int rangeStartId, int rangeEndId){
            VMTEMPLATE_POOL result = null;
            XmlRpcTemplateManagement xrum = (XmlRpcTemplateManagement)GetProxy(typeof(XmlRpcTemplateManagement));
            Array openNebulaReturnArr = xrum.oneTemplatePoolInfo(this.SessionSHA, templateFilterFlag, rangeStartId, rangeEndId);
            result = (VMTEMPLATE_POOL)Deserialize(typeof(VMTEMPLATE_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

    }
}

