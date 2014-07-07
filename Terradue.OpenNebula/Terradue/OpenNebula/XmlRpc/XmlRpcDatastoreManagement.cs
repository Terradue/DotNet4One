using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    [XmlRpcUrl(Terradue.OpenNebula.Configuration.XMLRPC_SERVER)]
    public interface XmlRpcDatastoreManagement : IXmlRpcProxy
    {


        [XmlRpcMethod("one.datastore.allocate")]
        Array oneDatastoreAllocate(string sessionSHA, string template);

        /*Description: Allocates a new datastore in OpenNebula.

            IN  String  The session string.
            IN  String  A string containing the template of the datastore. Syntax can be the usual attribute=value or XML.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The allocated resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.datastore.delete")]
        Array oneDatastoreDelete(string sessionSHA, int datastoreId);

        /*Description: Deletes the given datastore from the pool.

            IN  String  The session string.
            IN  Int     The object ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.datastore.info")]
        Array oneDatastoreInfo(string sessionSHA, int datastoreId);

        /*Description: Retrieves information for the datastore.

            IN  String  The session string.
            IN  Int     The object ID.
            OUT Boolean     true or false whenever is successful or not
            OUT String      The information string / The error string.
            OUT Int     Error code.

        */


        [XmlRpcMethod("one.datastorepool.info")]
        Array oneDatastorePoolInfo(string sessionSHA);

        /*Description: Retrieves information for all or part of the datastores in the pool.

            IN  String  The session string.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The information string / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.datastore.update")]
        Array oneDatastoreUpdate(string sessionSHA, int datastoreId, string template, int type);

        /*Description: Replaces the datastore template contents.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new template contents. Syntax can be the usual attribute=value or XML.
            IN  Int     Update type: 0: Replace the whole template. 1: Merge new template with the existing one.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.datastore.chmod")]
        Array oneDatastoreChmod(string sessionSHA, int datastoreId, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin);

        /*Description: Changes the permission bits of a datastore.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  Int     USER USE bit. If set to -1, it will not change.
            IN  Int     USER MANAGE bit. If set to -1, it will not change.
            IN  Int     USER ADMIN bit. If set to -1, it will not change.
            IN  Int     GROUP USE bit. If set to -1, it will not change.
            IN  Int     GROUP MANAGE bit. If set to -1, it will not change.
            IN  Int     GROUP ADMIN bit. If set to -1, it will not change.
            IN  Int     OTHER USE bit. If set to -1, it will not change.
            IN  Int     OTHER MANAGE bit. If set to -1, it will not change.
            IN  Int     OTHER ADMIN bit. If set to -1, it will not change.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.datastore.chown")]
        Array oneDatastoreChown(string sessionSHA, int datastoreId, int userId, int groupId);

        /*Description: Changes the ownership of a datastore.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  Int     The User ID of the new owner. If set to -1, the owner is not changed.
            IN  Int     The Group ID of the new group. If set to -1, the group is not changed.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The resource ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.datastore.rename")]
        Array oneDatastoreRename(string sessionSHA, int datastoreId, string newName);

        /*Description: Renames a datastore.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new name.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The VM ID / The error string.
            OUT Int     Error code.
        */

    }
}

