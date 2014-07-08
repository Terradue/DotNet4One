using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    [XmlRpcUrl(Terradue.OpenNebula.Configuration.XMLRPC_SERVER)]
    public interface XmlRpcTemplateManagement : IXmlRpcProxy
    {


        [XmlRpcMethod("one.template.allocate")]
        Array oneTemplateAllocate(string sessionSHA, string atributeValueContent);

        /*Description: Allocates a new template in OpenNebula.

            IN   String  The session string.
            IN   String  A string containing the template contents. Syntax can be the usual “attribute=value” or XML.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The allocated resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.template.clone")]
        Array oneTemplateClone(string sessionSHA, int templateId, string newTemplateName);

        /*Description: Clones an existing virtual machine template.

            IN   String  The session string.
            IN   Int     The ID of the template to be cloned.
            IN   String  Name for the new template.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The new template ID / The error string.
            OUT  Int     Error code.*/



        [XmlRpcMethod("one.template.delete")]
        Array oneTemplateDelete(string sessionSHA, int templateId);

        /*Description: Deletes the given template from the pool.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/



        [XmlRpcMethod("one.template.instantiate")]
        Array oneTemplateInstantiate(string sessionSHA, int templateId, string newVMInstanceName);

        /*Description: Instantiates a new virtual machine from a template.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  Name for the new VM instance. If it is an empty string, OpenNebula will assign one automatically.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The new virtual machine ID / The error string.
            OUT  Int     Error code.*/



        [XmlRpcMethod("one.template.update")]
        Array oneTemplateUpdate(string sessionSHA, int templateId, string atributeValueContent);

        /*Description: Replaces the template contents.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  The new template contents. Syntax can be the usual “attribute=value” or XML.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/



        [XmlRpcMethod("one.template.chmod")]
        Array oneTemplateChangeMod(string sessionSHA, int templateId, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin);

        /*Description: Changes the permission bits of a template.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     USER USE bit. If set to -1, it will not change.
            IN   Int     USER MANAGE bit. If set to -1, it will not change.
            IN   Int     USER ADMIN bit. If set to -1, it will not change.
            IN   Int     GROUP USE bit. If set to -1, it will not change.
            IN   Int     GROUP MANAGE bit. If set to -1, it will not change.
            IN   Int     GROUP ADMIN bit. If set to -1, it will not change.
            IN   Int     OTHER USE bit. If set to -1, it will not change.
            IN   Int     OTHER MANAGE bit. If set to -1, it will not change.
            IN   Int     OTHER ADMIN bit. If set to -1, it will not change.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.template.chown")]
        Array oneTemplateChangeOwner(string sessionSHA, int templateId, int newUserID, int newGroupId);

        /*Description: Changes the ownership of a template.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     The User ID of the new owner. If set to -1, the owner is not changed.
            IN   Int     The Group ID of the new group. If set to -1, the group is not changed.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/


        [XmlRpcMethod("one.template.rename")]
        Array oneTemplateRename(string sessionSHA, int templateId, string newName);

        /*Description: Renames a template.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new name.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The VM ID / The error string.
            OUT Int     Error code.*/
            

        [XmlRpcMethod("one.template.info")]
        Array oneTemplateInfo(string sessionSHA, int templateId);

        /*Description: Retrieves information for the template.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.templatepool.info")]
        Array oneTemplatePoolInfo(string sessionSHA, int templateFilterFlag, int rangeStartId, int rangeEndId);

        /*Description: Retrieves information for all or part of the Resources in the pool.

            IN   String  The session string.
            IN   Int     Filter flag
            - < = -3: Connected user's resources
            - -2: All resources
            - -1: Connected user's and his group's resources
            - > = 0: UID User's Resources
            IN   Int     Range start ID. Can be -1.
            IN   Int     Range end ID. Can be -1.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.
            The range can be used to retrieve a subset of the pool, from the 'start' to the 'end' ID. To retrieve the complete pool, use (-1, -1); to retrieve all the pool from a specific ID to the last one, use (<id>, -1), and to retrieve the first elements up to an ID, use (0, <id>).
             */
    }
}

