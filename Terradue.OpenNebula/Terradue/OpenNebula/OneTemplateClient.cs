using System;
using System.Net;
using System.IO;
using ServiceStack.Text;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneTemplateClient : OneClient {

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneTemplateClient"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneTemplateClient(string adminUsername, string adminPassword) : base(adminUsername, adminPassword){}

        /// <summary>
        /// Creates the template.
        /// </summary>
        /// <returns>The template id.</returns>
        /// <param name="content">Template Content.</param>
        public int CreateTemplate(string content){
            int result = 0;
            XmlRpcTemplateManagement xrum = XmlRpcProxyGen.Create<XmlRpcTemplateManagement>();
            Array openNebulaReturnArr = xrum.oneTemplateAllocate(this.SessionSHA, content);
            result = (bool)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Clones the template.
        /// </summary>
        /// <returns><c>true</c>, if template was cloned, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier of the template to clone.</param>
        /// <param name="name">Name of the new template.</param>
        public int CloneTemplate(int id, string name){
            int result = 0;
            XmlRpcTemplateManagement xrum = XmlRpcProxyGen.Create<XmlRpcTemplateManagement>();
            Array openNebulaReturnArr = xrum.oneTemplateClone(this.SessionSHA, id, name);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the template.
        /// </summary>
        /// <returns><c>true</c>, if template was deleted, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier of the template.</param>
        public bool DeleteTemplate(int id){
            bool result = false;
            XmlRpcTemplateManagement xrum = XmlRpcProxyGen.Create<XmlRpcTemplateManagement>();
            Array openNebulaReturnArr = xrum.oneTemplateDelete(this.SessionSHA, id);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the template info.
        /// </summary>
        /// <returns><c>true</c>, if template info was gotten, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        public bool GetTemplateInfo(int id){
            VMTEMPLATE result = null;
            XmlRpcTemplateManagement xrum = XmlRpcProxyGen.Create<XmlRpcTemplateManagement>();
            Array openNebulaReturnArr = xrum.oneTemplateInfo(this.SessionSHA, id);
            result = (VMTEMPLATE)Deserialize(typeof(VMTEMPLATE), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

    }
}

