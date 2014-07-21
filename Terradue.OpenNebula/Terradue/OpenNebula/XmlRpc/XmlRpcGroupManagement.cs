using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public interface XmlRpcGroupManagement : IXmlRpcProxy
    {
        [XmlRpcMethod("one.group.allocate")]
        Array oneGroupAllocate(string sessionSHA, string groupName);

        /*Description: Allocates a new group in OpenNebula.
        
           IN    String  The session string.
           IN    String  Name for the new group.
           OUT   Boolean     true or false whenever is successful or not
           OUT   Int/String  The allocated Group ID / The error string.
           OUT   Int     Error code.
        */


        [XmlRpcMethod("one.group.delete")]
        Array oneGroupDelete(string sessionSHA, int groupId);

        /*Description: Deletes the given group from the pool.
        
            IN  String  The session string.
            IN  Int     The object ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.group.info")]
        Array oneGroupInfo(string sessionSHA, int groupId);

        /*Description: Retrieves information for the group.
        
            IN  String  The session string.
            IN  Int     The object ID. If it is -1, then the connected user’s group info info is returned
            OUT Boolean     true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.group.update")]
        Array oneGroupUpdate(string sessionSHA, int groupId, string templateContent, int type);

        /*Description: Replaces the group template contents.
        
            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new template contents. Syntax can be the usual attribute=value or XML.
            IN  Int     Update type: 0: Replace the whole template. 1: Merge new template with the existing one.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.group.quota")]
        Array oneGroupQuota(string sessionSHA, int groupId, string templateContent);

        /*Description: Sets the group quota limits.
        
            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new quota template contents. Syntax can be the usual attribute=value or XML.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.group.addprovider")]
        Array oneGroupAddProvider(string sessionSHA, int groupId, int zoneId, int clusterId);

        /*Description: Adds a resource provider to the group
        
            IN  String  The session string.
            IN  Int     The group ID.
            IN  Int     The zone ID.
            IN  Int     The cluster ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.group.delprovider")]
        Array oneGroupDeleteProvider(string sessionSHA, int groupId, int zoneId, int clusterId);

        /*Description: Deletes a resource provider from the group
        
            IN  String  The session string.
            IN  Int     The group ID.
            IN  Int     The zone ID.
            IN  Int     The cluster ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.grouppool.info")]
        Array oneGroupPoolInfo(string sessionSHA);

        /*Description: Retrieves information for all the groups in the pool.
        
            IN  String  The session string.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.groupquota.info")]
        Array oneGroupQuotaInfo(string sessionSHA);

        /*Description: Returns the default group quota limits.
        
            IN  String  The session string.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.groupquota.update")]
        Array oneGroupQuotaUpdate(string sessionSHA, string templateContent);

        /*Description: Updates the default group quota limits.
        
            IN  String  The session string.
            IN  String  The new quota template contents. Syntax can be the usual attribute=value or XML.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The quota template contents / The error string.
            OUT Int     Error code.
        */


    }
}

