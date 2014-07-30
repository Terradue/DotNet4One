//
//  XmlRpcHostManagement.cs
//
//  Author:
//       Enguerran Boissier <enguerran.boissier@terradue.com>
//
//  Copyright (c) 2014 Terradue

using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {
    /// <summary>
    /// Xml rpc host management.
    /// </summary>
    public interface XmlRpcHostManagement : IXmlRpcProxy
    {


        [XmlRpcMethod("one.host.enable")]
        Array oneHostEnable(string sessionSHA, int hostId, bool enable);

        /*Description: Enables or disables the given host

            IN  String  The session string.
            IN  Int     The Host ID.
            IN  Boolean Set it to true/false to enable or disable the target Host.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.host.update")]
        Array oneHostUpdate(string sessionSHA, int hostId, string template, int type);

        /*Description: Replaces the host’s template contents.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new template contents. Syntax can be the usual attribute=value or XML.
            IN  Int     Update type: 0: Replace the whole template. 1: Merge new template with the existing one.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */

        [XmlRpcMethod("one.host.allocate")]
        Array oneHostAllocate(string sessionSHA, string hostname, string infoManagerName, string vmManagerName, string vnManagerName, int clusterId);

        /*Description: Allocates a new host in OpenNebula

            IN  String  The session string.
            IN  String  Hostname of the machine we want to add
            IN  String  The name of the information manager (im_mad_name), this values are taken from the oned.conf with the tag name IM_MAD (name)
            IN  String  The name of the virtual machine manager mad name (vmm_mad_name), this values are taken from the oned.conf with the tag name VM_MAD (name)
            IN  String  The name of the virtual network manager mad name (vnm_mad_name), see the Networking Subsystem documentation
            IN  Int     The cluster ID. If it is -1, this host won’t be added to any cluster.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The allocated Host ID / The error string.
            OUT Int     Error code.
        */

        [XmlRpcMethod("one.host.delete")]
        Array oneHostDelete(string sessionSHA, int hostId);

        /*Description: Deletes the given host from the pool

            IN  String  The session string.
            IN  Int     The object ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */

        [XmlRpcMethod("one.host.rename")]
        Array oneHostRename(string sessionSHA, int hostId, string newName);

        /*Description: Renames a host.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new name.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The VM ID / The error string.
            OUT Int     Error code.
        */

        [XmlRpcMethod("one.host.info")]
        Array oneHostInfo(string sessionSHA, int hostId);

        /*Description: Retrieves information for the host.

            IN  String  The session string.
            IN  Int The object ID.
            OUT Boolean true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int Error code.
        */

        [XmlRpcMethod("one.hostpool.info")]
        Array oneHostPoolInfo(string sessionSHA);

        /*Description: Retrieves information for all the hosts in the pool.

            IN  String  The session string.
            OUT Boolean true or false whenever is successful or not
            OUT String  The monitoring information string / The error string.
            OUT Int     Error code.
        */

        }
}

