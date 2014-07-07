using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    [XmlRpcUrl(Terradue.OpenNebula.Configuration.XMLRPC_SERVER)]
    public interface XmlRpcZoneManagement : IXmlRpcProxy
    {
        [XmlRpcMethod("one.zone.allocate")]
        Array oneZoneAllocate(string sessionSHA, string template);

        /*Description: Allocates a new zone in OpenNebula.
        
            IN  String  The session string.
            IN  String  A string containing the template of the zone. Syntax can be the usual attribute=value or XML.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The allocated resource ID / The error string.
            OUT Int     Error code.
        */

        [XmlRpcMethod("one.zone.delete")]
        Array oneZoneDelete(string sessionSHA, int zoneId);

        /*Description: Deletes the given zone from the pool.
        
            IN  String  The session string.
            IN  Int     The object ID.  
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.zone.update")]
        Array oneZoneUpdate(string sessionSHA, int zoneId, string template, int type);

        /*Description: Replaces the zone template contents.
        
            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new template contents. Syntax can be the usual attribute=value or XML.
            IN  Int     Update type: 0: Replace the whole template. 1: Merge new template with the existing one.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.zone.rename")]
        Array oneZoneRename(string sessionSHA, int zoneId, string newName);

        /*Description: Renames a zone.
        
            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new name.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.zone.info")]
        Array oneZoneInfo(string sessionSHA, int zoneId);

        /*Description: Retrieves information for the zone.
        
            IN  String  The session string.
            IN  Int     The object ID.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.zonepool.info")]
        Array oneZonePoolInfo(string sessionSHA);

        /*Description: Retrieves information for all the zones in the pool.
        
            IN  String  The session string.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The information string / The error string.
            OUT Int     Error code.
        */

    }
}

