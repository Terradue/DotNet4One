//
//  OneClient.Datastore.cs
//
//  Author:
//       Enguerran Boissier <enguerran.boissier@terradue.com>
//
//  Copyright (c) 2014 Terradue

using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {
    /// <summary>
    /// DotNet4One Client calling XML-RPC requests exposed by an OpenNebula server.
    /// XML-RPC commands for Datastore.
    /// </summary>
    public partial class OneClient {

        /// <summary>
        /// Allocates the datastore.
        /// </summary>
        /// <returns>The datastore.</returns>
        /// <param name="template">Template.</param>
        public int DatastoreAllocate(string template){
            int result = 0;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastoreAllocate(this.SessionSHA, template);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the datastore.
        /// </summary>
        /// <returns><c>true</c>, if datastore was deleted, <c>false</c> otherwise.</returns>
        /// <param name="dsId">Ds identifier.</param>
        public bool DatastoreDelete(int dsId){
            bool result = false;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastoreDelete(this.SessionSHA, dsId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the datastore info.
        /// </summary>
        /// <returns>The datastore info.</returns>
        /// <param name="dsId">Ds identifier.</param>
        public DATASTORE GetDatastoreInfo(int dsId){
            DATASTORE result = null;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastoreInfo(this.SessionSHA, dsId);
            result = (DATASTORE)Deserialize(typeof(DATASTORE), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the datastore list info.
        /// </summary>
        /// <returns>The datastore list info.</returns>
        public DATASTORE_POOL DatastoreGetPoolInfo(){
            DATASTORE_POOL result = null;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastorePoolInfo(this.SessionSHA);
            result = (DATASTORE_POOL)Deserialize(typeof(DATASTORE_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Updates the datastore.
        /// </summary>
        /// <returns><c>true</c>, if datastore was updated, <c>false</c> otherwise.</returns>
        /// <param name="dsId">Ds identifier.</param>
        /// <param name="template">Template.</param>
        /// <param name="type">Type.</param>
        public bool DatastoreUpdate(int dsId, string template, int type){
            bool result = false;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastoreUpdate(this.SessionSHA, dsId, template, type);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Change permissions og the Datastore
        /// </summary>
        /// <returns><c>true</c>, if chmod was datastored, <c>false</c> otherwise.</returns>
        /// <param name="dsId">Ds identifier.</param>
        /// <param name="userUse">User use.</param>
        /// <param name="userManage">User manage.</param>
        /// <param name="userAdmin">User admin.</param>
        /// <param name="groupUse">Group use.</param>
        /// <param name="groupManage">Group manage.</param>
        /// <param name="groupAdmin">Group admin.</param>
        /// <param name="otherUse">Other use.</param>
        /// <param name="otherManage">Other manage.</param>
        /// <param name="otherAdmin">Other admin.</param>
        public bool DatastoreChmod(int dsId, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin){
            bool result = false;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastoreChmod(this.SessionSHA, dsId, userUse, userManage, userAdmin, groupUse, groupManage, groupAdmin, otherUse, otherManage, otherAdmin);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Change owner of the Datastore
        /// </summary>
        /// <returns><c>true</c>, if chown was datastored, <c>false</c> otherwise.</returns>
        /// <param name="dsId">Ds identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="groupId">Group identifier.</param>
        public bool DatastoreChown(int dsId, int userId, int groupId){
            bool result = false;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastoreChown(this.SessionSHA, dsId, userId, groupId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Renames the datastore.
        /// </summary>
        /// <returns><c>true</c>, if datastore was renamed, <c>false</c> otherwise.</returns>
        /// <param name="dsId">Ds identifier.</param>
        /// <param name="name">Name.</param>
        public bool DatastoreRename(int dsId, string name){
            bool result = false;
            XmlRpcDatastoreManagement xrum = (XmlRpcDatastoreManagement)GetProxy(typeof(XmlRpcDatastoreManagement));
            Array openNebulaReturnArr = xrum.oneDatastoreRename(this.SessionSHA, dsId, name);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

    }
}

