using System;

namespace Terradue.OpenNebula {
    public partial class OneClient {
        /// <summary>
        /// Gets or sets the admin username.
        /// </summary>
        /// <value>The admin username.</value>
        string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the admin password.
        /// </summary>
        /// <value>The admin password.</value>
        string AdminPassword { get; set; }

        /// <summary>
        /// Gets the session SHA.
        /// </summary>
        /// <value>The session SHA.</value>
        protected string SessionSHA { 
            get { 
                return this.AdminUsername + ":" + this.AdminPassword; 
            } 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneUser"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneClient(string adminUsername, string adminPassword) {
            this.AdminUsername = adminUsername;
            this.AdminPassword = adminPassword;
        }

        /// <summary>
        /// Deserializes the response.
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="type">Type.</param>
        /// <param name="response">Response.</param>
        private object Deserialize(Type type, string response){
            object result = null;

            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(type);
            using (System.IO.MemoryStream s = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(response ?? ""))) {
                result = ser.Deserialize(s);
            }

            return result;
        }

    }

}

