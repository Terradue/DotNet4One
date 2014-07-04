using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    /*
     * Inspired from OpenNebula-CSharp-Adapter (https://github.com/Neuralab/OpenNebula-CSharp-Adapter)
    */

    [XmlRpcUrl(Terradue.OpenNebula.Configuration.XMLRPC_SERVER)]
    public interface XmlRpcVirtualMachineManagement : IXmlRpcProxy
    {


        [XmlRpcMethod("one.vm.allocate")]
        Array oneVirtualMachineAllocate(string sessionSHA, string atributeValueTemplate);

        /*Description: Allocates a new virtual machine in OpenNebula.

            IN   String  The session string.
            IN   String  A string containing the template for the vm. Syntax can be the usual “attribute=value” or XML.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The allocated resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vm.deploy")]
        Array oneVirtualMachineDeploy(string sessionSHA, int vmId, int hostId);

        /*Description: initiates the instance of the given vmid on the target host.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     The Host ID of the target host where the VM will be deployed.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The VM ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vm.action")]
        Array oneVirtualMachineAction(string sessionSHA, string action, int vmId);

        /*Description: submits an action to be performed on a virtual machine.

            IN   String  The session string.
            IN   String  the action name to be performed, see below.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The VM ID / The error string.
            OUT  Int     Error code.
            The action String must be one of the following:

            Action   Description
            shutdown    
            hold    
            release 
            stop    
            cancel  
            suspend 
            resume  
            restart 
            reboot  
            finalize    
            resubmit    
            resched 
            unresched   
            reset   */




        [XmlRpcMethod("one.vm.migrate")]
        Array oneVirtualMachineMigrate(string sessionSHA, int vmId, int targetHostId);

        /*Description: migrates one virtual machine (vid) to the target host (hid).

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     the target host id (hid) where we want to migrate the vm.
            IN   Boolean     if true we are indicating that we want livemigration, otherwise false.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The VM ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vm.savedisk")]
        Array oneVirtualMachineSaveDisk(string sessionSHA, int vmId, int diskId, string newImageName, string newImageType);

        /*Description: Sets the disk to be saved in the given image.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     Disk ID of the disk we want to save.
            IN   String  Name for the new Image where the disk will be saved.
            IN   String  Type for the new Image. If it is an empty string, then the default one will be used. See the existing types in the Image template reference.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The new allocated Image ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vm.attach")]
        Array oneVirtualMachineAttach(string sessionSHA, int vmId, string attributeValueSingleDiskVector);

        /*Description: Attaches a new disk to the virtual machine

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  A string containing a single DISK vector attribute. Syntax can be the usual “attribute=value” or XML.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The VM ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vm.detach")]
        Array oneVirtualMachineDetach(string sessionSHA, int vmId, int diskId);

        /*Description: Detaches a disk from a virtual machine

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     The disk ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The VM ID / The error string.
            OUT  Int     Error code.*/


        [XmlRpcMethod("one.vm.rename")]
        Array oneVirtualMachineRename(string sessionSHA, int vmId, string newName);

        /*Description: Renames a virtual machine

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new name.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The VM ID / The error string.
            OUT Int     Error code.*/




        [XmlRpcMethod("one.vm.chmod")]
        Array oneVirtualMachineChangeMod(string sessionSHA, int vmId, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin);

        /*Description: Changes the permission bits of a virtual machine.

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




        [XmlRpcMethod("one.vm.chown")]
        Array oneVirtualMachineChangeOwner(string sessionSHA, int vmId, int newUserID, int newGroupId);

        /*Description: Changes the ownership of a virtual machine.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     The User ID of the new owner. If set to -1, the owner is not changed.
            IN   Int     The Group ID of the new group. If set to -1, the group is not changed.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vm.info")]
        Array oneVirtualMachineInfo(string sessionSHA, int vmId);

        /*Description: Retrieves information for the virtual machine.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vm.monitoring")]
        Array oneVirtualMachineMonitoring(string sessionSHA, int vmId);

        /*Description: Returns the virtual machine monitoring records.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The monitoring information string / The error string.
            OUT  Int     Error code.
            The monitoring information returned is a list of VM elements. Each VM element contains the complete xml of the VM with the updated information returned by the poll action.

            For example:

            <MONITORING_DATA>
                <VM>
                    ...
                    <LAST_POLL>123</LAST_POLL>
                    ...
                </VM>
                <VM>
                    ...
                    <LAST_POLL>456</LAST_POLL>
                    ...
                </VM>
            </MONITORING_DATA>*/




        [XmlRpcMethod("one.vmpool.info")]
        Array oneVirtualMachinePoolInfo(string sessionSHA, int vmFilterFlag, int rangeStartId, int rangeEndId, int vmState);

        /*Description: Retrieves information for all or part of the VMs in the pool.

            IN   String  The session string.
            IN   Int     Filter flag
            - < = -3: Connected user's resources
            - -2: All resources
            - -1: Connected user's and his group's resources
            - > = 0: UID User's Resources
            IN   Int     Range start ID. Can be -1.
            IN   Int     Range end ID. Can be -1.
            IN   Int     VM state to filter by.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.
            The range can be used to retrieve a subset of the pool, from the 'start' to the 'end' ID. To retrieve the complete pool, use (-1, -1); to retrieve all the pool from a specific ID to the last one, use (<id>, -1), and to retrieve the first elements up to an ID, use (0, <id>).

            The state filter can be one of the following:

            Value    State
            -2   Any state, including DONE
            -1   Any state, except DONE
            0    INIT
            1    PENDING
            2    HOLD
            3    ACTIVE
            4    STOPPED
            5    SUSPENDED
            6    DONE
            7    FAILED*/




        [XmlRpcMethod("one.vmpool.monitoring")]
        Array oneVirtualMachinePoolMonitoring(string sessionSHA, int vmFilterFlag);

        /*Description: Returns all the virtual machine monitoring records.

            IN   String  The session string.
            IN   Int     Filter flag
            - < = -3: Connected user's resources
            - -2: All resources
            - -1: Connected user's and his group's resources
            - > = 0: UID User's Resources
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.
            See one.vm.monitoring.

            Sample output:

            <MONITORING_DATA>
                <VM>
                    <ID>0</ID>
                    <LAST_POLL>123</LAST_POLL>
                    ...
                </VM>
                <VM>
                    <ID>0</ID>
                    <LAST_POLL>456</LAST_POLL>
                    ...
                </VM>
                <VM>
                    <ID>3</ID>
                    <LAST_POLL>123</LAST_POLL>
                    ...
                </VM>
                <VM>
                    <ID>3</ID>
                    <LAST_POLL>456</LAST_POLL>
                    ...
                </VM>
            </MONITORING_DATA>*/



        [XmlRpcMethod("one.vmpool.accounting")]
        Array oneVirtualMachinePoolAccounting(string sessionSHA, int vmFilterFlag, int startTime, int endTime);

        /*Description: Returns the virtual machine history records.

            IN   String  The session string.
            IN   Int     Filter flag
            - < = -3: Connected user's resources
            - -2: All resources
            - -1: Connected user's and his group's resources
            - > = 0: UID User's Resources
            IN   Int     Start time for the time interval. Can be -1, in which case the time interval won't have a left boundary.
            IN   Int     End time for the time interval. Can be -1, in which case the time interval won't have a right boundary.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.
            The XML output is explained in detail in the accounting''oneacct'' guide.*/

    }


    /* ----- NOT YET IMPLEMENTED ----- 

    one.vm.attachnic
    one.vm.detachnic
    one.vm.snapshotcreate
    one.vm.snapshotdelete
    one.vm.snapshotrevert
    one.vm.resize
    one.vm.update
    one.vm.recover
    
    */
}

