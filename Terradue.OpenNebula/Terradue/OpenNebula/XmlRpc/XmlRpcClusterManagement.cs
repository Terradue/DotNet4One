//
//  XmlRpcClusterManagement.cs
//
//  Author:
//       Enguerran Boissier <enguerran.boissier@terradue.com>
//
//  Copyright (c) 2014 Terradue

using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {
    /// <summary>
    /// Xml rpc cluster management.
    /// </summary>
    public interface XmlRpcClusterManagement : IXmlRpcProxy
    {

        [XmlRpcMethod("one.cluster.allocate")]
        Array oneClusterAllocate(string sessionSHA, string newName);

        /*Description: Allocates a new cluster in OpenNebula.

            IN  String  The session string.
            IN  String  Name for the new cluster.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The allocated cluster ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.delete")]
        Array oneClusterDelete(string sessionSHA, int clusterId);

        /*Description: Deletes the given cluster from the pool.

            IN  String  The session string.
            IN  Int The object ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.update")]
        Array oneClusterUpdate(string sessionSHA, int clusterId, string templateContent, int type);

        /*Description: Replaces the cluster template contents.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new template contents. Syntax can be the usual attribute=value or XML.
            IN  Int     Update type: 0: Replace the whole template. 1: Merge new template with the existing one.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */
     

        [XmlRpcMethod("one.cluster.addhost")]
        Array oneClusterAddHost(string sessionSHA, int clusterId, int hostId);

        /*Description: Adds a host to the given cluster.

            IN  String  The session string.
            IN  Int     The cluster ID.
            IN  Int     The host ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.delhost")]
        Array oneClusterDeleteHost(string sessionSHA, int clusterId, int hostId);

        /*Description: Removes a host from the given cluster.

            IN  String  The session string.
            IN  Int     The cluster ID.
            IN  Int     The host ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.adddatastore")]
        Array oneClusterAddDataStore(string sessionSHA, int clusterId, int dsId);

        /*Description: Adds a datastore to the given cluster.

            IN  String  The session string.
            IN  Int     The cluster ID.
            IN  Int     The datastore ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.deldatastore")]
        Array oneClusterDeleteDataStore(string sessionSHA, int clusterId, int dsId);

        /*Description: Removes a datastore from the given cluster.

            IN  String  The session string.
            IN  Int     The cluster ID.
            IN  Int     The datastore ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.addvnet")]
        Array oneClusterAddVirtualNetwork(string sessionSHA, int clusterId, int vnId);

        /*Description: Adds a vnet to the given cluster.

            IN  String  The session string.
            IN  Int     The cluster ID.
            IN  Int     The vnet ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.delvnet")]
        Array oneClusterDeleteVirtualNetwork(string sessionSHA, int clusterId, int vnId);

        /*Description: Removes a vnet from the given cluster.

            IN  String  The session string.
            IN  Int     The cluster ID.
            IN  Int     The vnet ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.rename")]
        Array oneClusterRename(string sessionSHA, int clusterId, string newName);

        /*Description: Renames a cluster.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new name.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The VM ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.cluster.info")]
        Array oneClusterInfo(string sessionSHA, int clusterId);

        /*Description: Retrieves information for the cluster.

            IN  String  The session string.
            IN  Int     The object ID.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.clusterpool.info")]
        Array oneClusterPoolInfo(string sessionSHA);

        /*Description: Retrieves information for the clusters in the pool.

            IN  String  The session string.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int     Error code.
        */
    }
}
    