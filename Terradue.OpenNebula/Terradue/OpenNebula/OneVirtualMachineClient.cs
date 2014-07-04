using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneVirtualMachineClient : OneClient {

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneVirtualMachineClient"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneVirtualMachineClient(string adminUsername, string adminPassword) : base(adminUsername, adminPassword){}

        /// <summary>
        /// Allocates the Virtual Machine.
        /// </summary>
        /// <returns>The VM.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="template">Template for the VM.</param>
        public int AllocateVM(string template){
            int result = 0;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineAllocate(this.SessionSHA, template);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deploies the VM
        /// </summary>
        /// <returns><c>true</c>, if VM was deployed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="hostId">Host identifier.</param>
        public bool DeployVM(int id, int hostId){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineDeploy(this.SessionSHA, id, hostId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Action performed on the VM
        /// </summary>
        /// <returns><c>true</c>, if on VM was actioned, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="action">Action.</param>
        public bool ActionOnVM(int id, string action){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineAction(this.SessionSHA, action, id);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Migrates the VM
        /// </summary>
        /// <returns><c>true</c>, if VM was migrated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="targetId">Target identifier.</param>
        public bool MigrateVM(int id, int targetId){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineMigrate(this.SessionSHA, id, targetId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Sets the disk of the VM to be saved in the given image.
        /// </summary>
        /// <returns>The new VM id.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="diskId">Disk identifier.</param>
        /// <param name="newImageName">New image name.</param>
        /// <param name="newImageType">New image type.</param>
        public int SaveDisksVM(int id, int diskId, string newImageName, string newImageType){
            int result = 0;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineSaveDisk(this.SessionSHA, id, diskId, newImageName, newImageType);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Attachs new disk to the VM
        /// </summary>
        /// <returns><c>true</c>, if disk was attached, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="attributeValueSingleDiskVector">Attribute value single disk vector.</param>
        public bool AttachDiskVM(int id, string attributeValueSingleDiskVector){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineAttach(this.SessionSHA, id, attributeValueSingleDiskVector);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Detaches the disk from the VM
        /// </summary>
        /// <returns><c>true</c>, if disk was detached, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="diskId">Disk identifier.</param>
        public bool VMDetachDiskVM(int id, int diskId){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineDetach(this.SessionSHA, id, diskId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Change the VM permissions
        /// </summary>
        /// <returns><c>true</c>, if change was done, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="userUse">User use.</param>
        /// <param name="userManage">User manage.</param>
        /// <param name="userAdmin">User admin.</param>
        /// <param name="groupUse">Group use.</param>
        /// <param name="groupManage">Group manage.</param>
        /// <param name="groupAdmin">Group admin.</param>
        /// <param name="otherUse">Other use.</param>
        /// <param name="otherManage">Other manage.</param>
        /// <param name="otherAdmin">Other admin.</param>
        public bool VMChangeMod(int id, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineChangeMod(this.SessionSHA, id, userUse, userManage, userAdmin, groupUse, groupManage, groupAdmin, otherUse, otherManage, otherAdmin);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Change the owner of the VM
        /// </summary>
        /// <returns><c>true</c>, if change was done, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newUserID">New user I.</param>
        /// <param name="newGroupId">New group identifier.</param>
        public bool VMChangeOwner(int id, int newUserID, int newGroupId){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineChangeOwner(this.SessionSHA, id, newUserID, newGroupId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Renames the VM
        /// </summary>
        /// <returns><c>true</c>, if VM was renamed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newName">New name.</param>
        public bool RenameVM(int id, string newName){
            bool result = false;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineRename(this.SessionSHA, id, newName);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the VM info.
        /// </summary>
        /// <returns>The VM info.</returns>
        /// <param name="id">Identifier.</param>
        public VM GetVMInfo(int id){
            VM result = null;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineInfo(this.SessionSHA, id);
            result = (VM)Deserialize(typeof(VM), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }


        /// <summary>
        /// Gets the VM list info.
        /// </summary>
        /// <returns>The VM list info.</returns>
        /// <param name="templateFilterFlag">Template filter flag.</param>
        /// <param name="rangeStartId">Range start identifier.</param>
        /// <param name="rangeEndId">Range end identifier.</param>
        /// <param name="vmState">Vm state.</param>
        public VM_POOL GetVMListInfo(int templateFilterFlag, int rangeStartId, int rangeEndId, int vmState){
            VM_POOL result = null;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachinePoolInfo(this.SessionSHA, templateFilterFlag, rangeStartId, rangeEndId, vmState);
            result = (VM_POOL)Deserialize(typeof(VM_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the VM monitoring info.
        /// </summary>
        /// <returns>The VM monitoring info.</returns>
        /// <param name="id">Identifier.</param>
        public VM_POOL GetVMMonitoringInfo(int id){
            VM_POOL result = null;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachineMonitoring(this.SessionSHA, id);
            result = (VM_POOL)Deserialize(typeof(VM_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the VM list monitoring info.
        /// </summary>
        /// <returns>The VM list monitoring info.</returns>
        /// <param name="vmFilterFlag">Vm filter flag.</param>
        public VM_POOL GetVMListMonitoringInfo(int vmFilterFlag){
            VM_POOL result = null;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachinePoolMonitoring(this.SessionSHA, vmFilterFlag);
            result = (VM_POOL)Deserialize(typeof(VM_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the VM list history.
        /// </summary>
        /// <returns>The VM list history.</returns>
        /// <param name="vmFilterFlag">Vm filter flag.</param>
        /// <param name="startTime">Start time.</param>
        /// <param name="endTime">End time.</param>
        public VMHISTORY_RECORDSHISTORY GetVMListHistory(int vmFilterFlag, int startTime, int endTime){
            VMHISTORY_RECORDSHISTORY result = null;
            XmlRpcVirtualMachineManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualMachineManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualMachinePoolAccounting(this.SessionSHA, vmFilterFlag, startTime, endTime);
            result = (VMHISTORY_RECORDSHISTORY)Deserialize(typeof(VMHISTORY_RECORDSHISTORY), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }
    }
}

