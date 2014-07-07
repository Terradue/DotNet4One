using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneClusterClient : OneClient {

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneClusterClient"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneClusterClient(string adminUsername, string adminPassword) : base(adminUsername, adminPassword){}

        /// <summary>
        /// Allocates the cluster.
        /// </summary>
        /// <returns>The cluster.</returns>
        /// <param name="content">Content.</param>
        public int AllocateCluster(string content){
            int result = 0;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterAllocate(this.SessionSHA, content);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the cluster.
        /// </summary>
        /// <returns><c>true</c>, if cluster was deleted, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        public bool DeleteCluster(int id){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterDelete(this.SessionSHA, id);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Updates the cluster.
        /// </summary>
        /// <returns><c>true</c>, if cluster was updated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="templateContent">Template content.</param>
        /// <param name="type">Type.</param>
        public bool UpdateCluster(int id, string templateContent, int type){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterUpdate(this.SessionSHA, id, templateContent, type);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Adds the host to cluster.
        /// </summary>
        /// <returns><c>true</c>, if host to cluster was added, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="hostId">Host identifier.</param>
        public bool AddHostToCluster(int id, int hostId){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterAddHost(this.SessionSHA, id, hostId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Removes the host from cluster.
        /// </summary>
        /// <returns><c>true</c>, if host from cluster was removed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="hostId">Host identifier.</param>
        public bool DeleteHostFromCluster(int id, int hostId){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterDeleteHost(this.SessionSHA, id, hostId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Adds the data store to cluster.
        /// </summary>
        /// <returns><c>true</c>, if data store to cluster was added, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="datastoreId">Datastore identifier.</param>
        public bool AddDataStoreToCluster(int id, int datastoreId){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterAddDataStore(this.SessionSHA, id, datastoreId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Deletes the data store from cluster.
        /// </summary>
        /// <returns><c>true</c>, if data store from cluster was deleted, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="datastoreId">Datastore identifier.</param>
        public bool DeleteDataStoreFromCluster(int id, int datastoreId){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterDeleteDataStore(this.SessionSHA, id, datastoreId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Adds the virtual network to cluster.
        /// </summary>
        /// <returns><c>true</c>, if virtual network to cluster was added, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="vnId">Vn identifier.</param>
        public bool AddVirtualNetworkToCluster(int id, int vnId){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterAddVirtualNetwork(this.SessionSHA, id, vnId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Deletes the virtual network from cluster.
        /// </summary>
        /// <returns><c>true</c>, if virtual network from cluster was deleted, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="vnId">Vn identifier.</param>
        public bool DeleteVirtualNetworkFromCluster(int id, int vnId){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterDeleteVirtualNetwork(this.SessionSHA, id, vnId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Renames the cluster.
        /// </summary>
        /// <returns><c>true</c>, if cluster was renamed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newName">New name.</param>
        public bool RenameCluster(int id, string newName){
            bool result = false;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterRename(this.SessionSHA, id, newName);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the cluster info.
        /// </summary>
        /// <returns>The cluster info.</returns>
        /// <param name="id">Identifier.</param>
        public CLUSTER GetClusterInfo(int id){
            CLUSTER result = null;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterInfo(this.SessionSHA, id);
            result = (CLUSTER)Deserialize(typeof(CLUSTER), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the cluster list info.
        /// </summary>
        /// <returns>The cluster list info.</returns>
        public CLUSTER_POOL GetClusterListInfo(){
            CLUSTER_POOL result = null;
            XmlRpcClusterManagement xrum = XmlRpcProxyGen.Create<XmlRpcClusterManagement>();
            Array openNebulaReturnArr = xrum.oneClusterPoolInfo(this.SessionSHA);
            result = (CLUSTER_POOL)Deserialize(typeof(CLUSTER_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

    }
}

