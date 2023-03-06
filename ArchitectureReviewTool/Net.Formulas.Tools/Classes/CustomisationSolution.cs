using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Net.Formulas.Tools.Classes
{
    /*

    // REMARQUE : Le code généré peut nécessiter au moins .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ImportExportXml
    {

        private ImportExportXmlEntity[] entitiesField;

        private ImportExportXmlRoles rolesField;

        private ImportExportXmlWorkflow[] workflowsField;

        private ImportExportXmlFieldSecurityProfiles fieldSecurityProfilesField;

        private object templatesField;

        private object entityMapsField;

        private ImportExportXmlEntityRelationship[] entityRelationshipsField;

        private object organizationSettingsField;

        private ImportExportXmlOptionset[] optionsetsField;

        private object customControlsField;

        private object entityDataProvidersField;

        private ImportExportXmlCanvasApp[] canvasAppsField;

        private ImportExportXmlConnectionreference[] connectionreferencesField;

        private ImportExportXmlLanguages languagesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Entity", IsNullable = false)]
        public ImportExportXmlEntity[] Entities
        {
            get
            {
                return this.entitiesField;
            }
            set
            {
                this.entitiesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlRoles Roles
        {
            get
            {
                return this.rolesField;
            }
            set
            {
                this.rolesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Workflow", IsNullable = false)]
        public ImportExportXmlWorkflow[] Workflows
        {
            get
            {
                return this.workflowsField;
            }
            set
            {
                this.workflowsField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlFieldSecurityProfiles FieldSecurityProfiles
        {
            get
            {
                return this.fieldSecurityProfilesField;
            }
            set
            {
                this.fieldSecurityProfilesField = value;
            }
        }

        /// <remarks/>
        public object Templates
        {
            get
            {
                return this.templatesField;
            }
            set
            {
                this.templatesField = value;
            }
        }

        /// <remarks/>
        public object EntityMaps
        {
            get
            {
                return this.entityMapsField;
            }
            set
            {
                this.entityMapsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("EntityRelationship", IsNullable = false)]
        public ImportExportXmlEntityRelationship[] EntityRelationships
        {
            get
            {
                return this.entityRelationshipsField;
            }
            set
            {
                this.entityRelationshipsField = value;
            }
        }

        /// <remarks/>
        public object OrganizationSettings
        {
            get
            {
                return this.organizationSettingsField;
            }
            set
            {
                this.organizationSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("optionset", IsNullable = false)]
        public ImportExportXmlOptionset[] optionsets
        {
            get
            {
                return this.optionsetsField;
            }
            set
            {
                this.optionsetsField = value;
            }
        }

        /// <remarks/>
        public object CustomControls
        {
            get
            {
                return this.customControlsField;
            }
            set
            {
                this.customControlsField = value;
            }
        }

        /// <remarks/>
        public object EntityDataProviders
        {
            get
            {
                return this.entityDataProvidersField;
            }
            set
            {
                this.entityDataProvidersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CanvasApp", IsNullable = false)]
        public ImportExportXmlCanvasApp[] CanvasApps
        {
            get
            {
                return this.canvasAppsField;
            }
            set
            {
                this.canvasAppsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("connectionreference", IsNullable = false)]
        public ImportExportXmlConnectionreference[] connectionreferences
        {
            get
            {
                return this.connectionreferencesField;
            }
            set
            {
                this.connectionreferencesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlLanguages Languages
        {
            get
            {
                return this.languagesField;
            }
            set
            {
                this.languagesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntity
    {

        private ImportExportXmlEntityName nameField;

        private ImportExportXmlEntityEntityInfo entityInfoField;

        private ImportExportXmlEntityForms[] formXmlField;

        private ImportExportXmlEntitySavedQueries savedQueriesField;

        private ImportExportXmlEntityRibbonDiffXml ribbonDiffXmlField;

        /// <remarks/>
        public ImportExportXmlEntityName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityEntityInfo EntityInfo
        {
            get
            {
                return this.entityInfoField;
            }
            set
            {
                this.entityInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("forms", IsNullable = false)]
        public ImportExportXmlEntityForms[] FormXml
        {
            get
            {
                return this.formXmlField;
            }
            set
            {
                this.formXmlField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntitySavedQueries SavedQueries
        {
            get
            {
                return this.savedQueriesField;
            }
            set
            {
                this.savedQueriesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityRibbonDiffXml RibbonDiffXml
        {
            get
            {
                return this.ribbonDiffXmlField;
            }
            set
            {
                this.ribbonDiffXmlField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityName
    {

        private string localizedNameField;

        private string originalNameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LocalizedName
        {
            get
            {
                return this.localizedNameField;
            }
            set
            {
                this.localizedNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OriginalName
        {
            get
            {
                return this.originalNameField;
            }
            set
            {
                this.originalNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfo
    {

        private ImportExportXmlEntityEntityInfoEntity entityField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntity entity
        {
            get
            {
                return this.entityField;
            }
            set
            {
                this.entityField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntity
    {

        private ImportExportXmlEntityEntityInfoEntityLocalizedNames localizedNamesField;

        private ImportExportXmlEntityEntityInfoEntityLocalizedCollectionNames localizedCollectionNamesField;

        private ImportExportXmlEntityEntityInfoEntityDescriptions descriptionsField;

        private ImportExportXmlEntityEntityInfoEntityAttribute[] attributesField;

        private string entitySetNameField;

        private byte isDuplicateCheckSupportedField;

        private byte isBusinessProcessEnabledField;

        private byte isRequiredOfflineField;

        private byte isInteractionCentricEnabledField;

        private byte isCollaborationField;

        private byte autoRouteToOwnerQueueField;

        private byte isConnectionsEnabledField;

        private byte isDocumentManagementEnabledField;

        private byte autoCreateAccessTeamsField;

        private byte isOneNoteIntegrationEnabledField;

        private byte isKnowledgeManagementEnabledField;

        private byte isSLAEnabledField;

        private byte isDocumentRecommendationsEnabledField;

        private byte isBPFEntityField;

        private string ownershipTypeMaskField;

        private byte isAuditEnabledField;

        private byte isRetrieveAuditEnabledField;

        private byte isRetrieveMultipleAuditEnabledField;

        private byte isActivityField;

        private string activityTypeMaskField;

        private byte isActivityPartyField;

        private byte isReplicatedField;

        private byte isReplicationUserFilteredField;

        private byte isMailMergeEnabledField;

        private byte isVisibleInMobileField;

        private byte isVisibleInMobileClientField;

        private byte isReadOnlyInMobileClientField;

        private byte isOfflineInMobileClientField;

        private byte daysSinceRecordLastModifiedField;

        private object mobileOfflineFiltersField;

        private byte isMapiGridEnabledField;

        private byte isReadingPaneEnabledField;

        private byte isQuickCreateEnabledField;

        private byte syncToExternalSearchIndexField;

        private string introducedVersionField;

        private byte isCustomizableField;

        private bool isCustomizableFieldSpecified;

        private byte isRenameableField;

        private bool isRenameableFieldSpecified;

        private byte isMappableField;

        private bool isMappableFieldSpecified;

        private byte canModifyAuditSettingsField;

        private bool canModifyAuditSettingsFieldSpecified;

        private byte canModifyMobileVisibilityField;

        private bool canModifyMobileVisibilityFieldSpecified;

        private byte canModifyMobileClientVisibilityField;

        private bool canModifyMobileClientVisibilityFieldSpecified;

        private byte canModifyMobileClientReadOnlyField;

        private bool canModifyMobileClientReadOnlyFieldSpecified;

        private byte canModifyMobileClientOfflineField;

        private bool canModifyMobileClientOfflineFieldSpecified;

        private byte canModifyConnectionSettingsField;

        private bool canModifyConnectionSettingsFieldSpecified;

        private byte canModifyDuplicateDetectionSettingsField;

        private bool canModifyDuplicateDetectionSettingsFieldSpecified;

        private byte canModifyMailMergeSettingsField;

        private bool canModifyMailMergeSettingsFieldSpecified;

        private byte canModifyQueueSettingsField;

        private bool canModifyQueueSettingsFieldSpecified;

        private byte canCreateAttributesField;

        private bool canCreateAttributesFieldSpecified;

        private byte canCreateFormsField;

        private bool canCreateFormsFieldSpecified;

        private byte canCreateChartsField;

        private bool canCreateChartsFieldSpecified;

        private byte canCreateViewsField;

        private bool canCreateViewsFieldSpecified;

        private byte canModifyAdditionalSettingsField;

        private bool canModifyAdditionalSettingsFieldSpecified;

        private byte canEnableSyncToExternalSearchIndexField;

        private bool canEnableSyncToExternalSearchIndexFieldSpecified;

        private byte enforceStateTransitionsField;

        private byte canChangeHierarchicalRelationshipField;

        private bool canChangeHierarchicalRelationshipFieldSpecified;

        private byte entityHelpUrlEnabledField;

        private byte changeTrackingEnabledField;

        private byte canChangeTrackingBeEnabledField;

        private bool canChangeTrackingBeEnabledFieldSpecified;

        private byte isEnabledForExternalChannelsField;

        private byte isSolutionAwareField;

        private string hasRelatedNotesField;

        private string nameField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityLocalizedNames LocalizedNames
        {
            get
            {
                return this.localizedNamesField;
            }
            set
            {
                this.localizedNamesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityLocalizedCollectionNames LocalizedCollectionNames
        {
            get
            {
                return this.localizedCollectionNamesField;
            }
            set
            {
                this.localizedCollectionNamesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityDescriptions Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attribute", IsNullable = false)]
        public ImportExportXmlEntityEntityInfoEntityAttribute[] attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }

        /// <remarks/>
        public string EntitySetName
        {
            get
            {
                return this.entitySetNameField;
            }
            set
            {
                this.entitySetNameField = value;
            }
        }

        /// <remarks/>
        public byte IsDuplicateCheckSupported
        {
            get
            {
                return this.isDuplicateCheckSupportedField;
            }
            set
            {
                this.isDuplicateCheckSupportedField = value;
            }
        }

        /// <remarks/>
        public byte IsBusinessProcessEnabled
        {
            get
            {
                return this.isBusinessProcessEnabledField;
            }
            set
            {
                this.isBusinessProcessEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsRequiredOffline
        {
            get
            {
                return this.isRequiredOfflineField;
            }
            set
            {
                this.isRequiredOfflineField = value;
            }
        }

        /// <remarks/>
        public byte IsInteractionCentricEnabled
        {
            get
            {
                return this.isInteractionCentricEnabledField;
            }
            set
            {
                this.isInteractionCentricEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsCollaboration
        {
            get
            {
                return this.isCollaborationField;
            }
            set
            {
                this.isCollaborationField = value;
            }
        }

        /// <remarks/>
        public byte AutoRouteToOwnerQueue
        {
            get
            {
                return this.autoRouteToOwnerQueueField;
            }
            set
            {
                this.autoRouteToOwnerQueueField = value;
            }
        }

        /// <remarks/>
        public byte IsConnectionsEnabled
        {
            get
            {
                return this.isConnectionsEnabledField;
            }
            set
            {
                this.isConnectionsEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsDocumentManagementEnabled
        {
            get
            {
                return this.isDocumentManagementEnabledField;
            }
            set
            {
                this.isDocumentManagementEnabledField = value;
            }
        }

        /// <remarks/>
        public byte AutoCreateAccessTeams
        {
            get
            {
                return this.autoCreateAccessTeamsField;
            }
            set
            {
                this.autoCreateAccessTeamsField = value;
            }
        }

        /// <remarks/>
        public byte IsOneNoteIntegrationEnabled
        {
            get
            {
                return this.isOneNoteIntegrationEnabledField;
            }
            set
            {
                this.isOneNoteIntegrationEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsKnowledgeManagementEnabled
        {
            get
            {
                return this.isKnowledgeManagementEnabledField;
            }
            set
            {
                this.isKnowledgeManagementEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsSLAEnabled
        {
            get
            {
                return this.isSLAEnabledField;
            }
            set
            {
                this.isSLAEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsDocumentRecommendationsEnabled
        {
            get
            {
                return this.isDocumentRecommendationsEnabledField;
            }
            set
            {
                this.isDocumentRecommendationsEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsBPFEntity
        {
            get
            {
                return this.isBPFEntityField;
            }
            set
            {
                this.isBPFEntityField = value;
            }
        }

        /// <remarks/>
        public string OwnershipTypeMask
        {
            get
            {
                return this.ownershipTypeMaskField;
            }
            set
            {
                this.ownershipTypeMaskField = value;
            }
        }

        /// <remarks/>
        public byte IsAuditEnabled
        {
            get
            {
                return this.isAuditEnabledField;
            }
            set
            {
                this.isAuditEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsRetrieveAuditEnabled
        {
            get
            {
                return this.isRetrieveAuditEnabledField;
            }
            set
            {
                this.isRetrieveAuditEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsRetrieveMultipleAuditEnabled
        {
            get
            {
                return this.isRetrieveMultipleAuditEnabledField;
            }
            set
            {
                this.isRetrieveMultipleAuditEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsActivity
        {
            get
            {
                return this.isActivityField;
            }
            set
            {
                this.isActivityField = value;
            }
        }

        /// <remarks/>
        public string ActivityTypeMask
        {
            get
            {
                return this.activityTypeMaskField;
            }
            set
            {
                this.activityTypeMaskField = value;
            }
        }

        /// <remarks/>
        public byte IsActivityParty
        {
            get
            {
                return this.isActivityPartyField;
            }
            set
            {
                this.isActivityPartyField = value;
            }
        }

        /// <remarks/>
        public byte IsReplicated
        {
            get
            {
                return this.isReplicatedField;
            }
            set
            {
                this.isReplicatedField = value;
            }
        }

        /// <remarks/>
        public byte IsReplicationUserFiltered
        {
            get
            {
                return this.isReplicationUserFilteredField;
            }
            set
            {
                this.isReplicationUserFilteredField = value;
            }
        }

        /// <remarks/>
        public byte IsMailMergeEnabled
        {
            get
            {
                return this.isMailMergeEnabledField;
            }
            set
            {
                this.isMailMergeEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsVisibleInMobile
        {
            get
            {
                return this.isVisibleInMobileField;
            }
            set
            {
                this.isVisibleInMobileField = value;
            }
        }

        /// <remarks/>
        public byte IsVisibleInMobileClient
        {
            get
            {
                return this.isVisibleInMobileClientField;
            }
            set
            {
                this.isVisibleInMobileClientField = value;
            }
        }

        /// <remarks/>
        public byte IsReadOnlyInMobileClient
        {
            get
            {
                return this.isReadOnlyInMobileClientField;
            }
            set
            {
                this.isReadOnlyInMobileClientField = value;
            }
        }

        /// <remarks/>
        public byte IsOfflineInMobileClient
        {
            get
            {
                return this.isOfflineInMobileClientField;
            }
            set
            {
                this.isOfflineInMobileClientField = value;
            }
        }

        /// <remarks/>
        public byte DaysSinceRecordLastModified
        {
            get
            {
                return this.daysSinceRecordLastModifiedField;
            }
            set
            {
                this.daysSinceRecordLastModifiedField = value;
            }
        }

        /// <remarks/>
        public object MobileOfflineFilters
        {
            get
            {
                return this.mobileOfflineFiltersField;
            }
            set
            {
                this.mobileOfflineFiltersField = value;
            }
        }

        /// <remarks/>
        public byte IsMapiGridEnabled
        {
            get
            {
                return this.isMapiGridEnabledField;
            }
            set
            {
                this.isMapiGridEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsReadingPaneEnabled
        {
            get
            {
                return this.isReadingPaneEnabledField;
            }
            set
            {
                this.isReadingPaneEnabledField = value;
            }
        }

        /// <remarks/>
        public byte IsQuickCreateEnabled
        {
            get
            {
                return this.isQuickCreateEnabledField;
            }
            set
            {
                this.isQuickCreateEnabledField = value;
            }
        }

        /// <remarks/>
        public byte SyncToExternalSearchIndex
        {
            get
            {
                return this.syncToExternalSearchIndexField;
            }
            set
            {
                this.syncToExternalSearchIndexField = value;
            }
        }

        /// <remarks/>
        public string IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        public byte IsCustomizable
        {
            get
            {
                return this.isCustomizableField;
            }
            set
            {
                this.isCustomizableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsCustomizableSpecified
        {
            get
            {
                return this.isCustomizableFieldSpecified;
            }
            set
            {
                this.isCustomizableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte IsRenameable
        {
            get
            {
                return this.isRenameableField;
            }
            set
            {
                this.isRenameableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsRenameableSpecified
        {
            get
            {
                return this.isRenameableFieldSpecified;
            }
            set
            {
                this.isRenameableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte IsMappable
        {
            get
            {
                return this.isMappableField;
            }
            set
            {
                this.isMappableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsMappableSpecified
        {
            get
            {
                return this.isMappableFieldSpecified;
            }
            set
            {
                this.isMappableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyAuditSettings
        {
            get
            {
                return this.canModifyAuditSettingsField;
            }
            set
            {
                this.canModifyAuditSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyAuditSettingsSpecified
        {
            get
            {
                return this.canModifyAuditSettingsFieldSpecified;
            }
            set
            {
                this.canModifyAuditSettingsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyMobileVisibility
        {
            get
            {
                return this.canModifyMobileVisibilityField;
            }
            set
            {
                this.canModifyMobileVisibilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyMobileVisibilitySpecified
        {
            get
            {
                return this.canModifyMobileVisibilityFieldSpecified;
            }
            set
            {
                this.canModifyMobileVisibilityFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyMobileClientVisibility
        {
            get
            {
                return this.canModifyMobileClientVisibilityField;
            }
            set
            {
                this.canModifyMobileClientVisibilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyMobileClientVisibilitySpecified
        {
            get
            {
                return this.canModifyMobileClientVisibilityFieldSpecified;
            }
            set
            {
                this.canModifyMobileClientVisibilityFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyMobileClientReadOnly
        {
            get
            {
                return this.canModifyMobileClientReadOnlyField;
            }
            set
            {
                this.canModifyMobileClientReadOnlyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyMobileClientReadOnlySpecified
        {
            get
            {
                return this.canModifyMobileClientReadOnlyFieldSpecified;
            }
            set
            {
                this.canModifyMobileClientReadOnlyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyMobileClientOffline
        {
            get
            {
                return this.canModifyMobileClientOfflineField;
            }
            set
            {
                this.canModifyMobileClientOfflineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyMobileClientOfflineSpecified
        {
            get
            {
                return this.canModifyMobileClientOfflineFieldSpecified;
            }
            set
            {
                this.canModifyMobileClientOfflineFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyConnectionSettings
        {
            get
            {
                return this.canModifyConnectionSettingsField;
            }
            set
            {
                this.canModifyConnectionSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyConnectionSettingsSpecified
        {
            get
            {
                return this.canModifyConnectionSettingsFieldSpecified;
            }
            set
            {
                this.canModifyConnectionSettingsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyDuplicateDetectionSettings
        {
            get
            {
                return this.canModifyDuplicateDetectionSettingsField;
            }
            set
            {
                this.canModifyDuplicateDetectionSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyDuplicateDetectionSettingsSpecified
        {
            get
            {
                return this.canModifyDuplicateDetectionSettingsFieldSpecified;
            }
            set
            {
                this.canModifyDuplicateDetectionSettingsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyMailMergeSettings
        {
            get
            {
                return this.canModifyMailMergeSettingsField;
            }
            set
            {
                this.canModifyMailMergeSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyMailMergeSettingsSpecified
        {
            get
            {
                return this.canModifyMailMergeSettingsFieldSpecified;
            }
            set
            {
                this.canModifyMailMergeSettingsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyQueueSettings
        {
            get
            {
                return this.canModifyQueueSettingsField;
            }
            set
            {
                this.canModifyQueueSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyQueueSettingsSpecified
        {
            get
            {
                return this.canModifyQueueSettingsFieldSpecified;
            }
            set
            {
                this.canModifyQueueSettingsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanCreateAttributes
        {
            get
            {
                return this.canCreateAttributesField;
            }
            set
            {
                this.canCreateAttributesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanCreateAttributesSpecified
        {
            get
            {
                return this.canCreateAttributesFieldSpecified;
            }
            set
            {
                this.canCreateAttributesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanCreateForms
        {
            get
            {
                return this.canCreateFormsField;
            }
            set
            {
                this.canCreateFormsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanCreateFormsSpecified
        {
            get
            {
                return this.canCreateFormsFieldSpecified;
            }
            set
            {
                this.canCreateFormsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanCreateCharts
        {
            get
            {
                return this.canCreateChartsField;
            }
            set
            {
                this.canCreateChartsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanCreateChartsSpecified
        {
            get
            {
                return this.canCreateChartsFieldSpecified;
            }
            set
            {
                this.canCreateChartsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanCreateViews
        {
            get
            {
                return this.canCreateViewsField;
            }
            set
            {
                this.canCreateViewsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanCreateViewsSpecified
        {
            get
            {
                return this.canCreateViewsFieldSpecified;
            }
            set
            {
                this.canCreateViewsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanModifyAdditionalSettings
        {
            get
            {
                return this.canModifyAdditionalSettingsField;
            }
            set
            {
                this.canModifyAdditionalSettingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanModifyAdditionalSettingsSpecified
        {
            get
            {
                return this.canModifyAdditionalSettingsFieldSpecified;
            }
            set
            {
                this.canModifyAdditionalSettingsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanEnableSyncToExternalSearchIndex
        {
            get
            {
                return this.canEnableSyncToExternalSearchIndexField;
            }
            set
            {
                this.canEnableSyncToExternalSearchIndexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanEnableSyncToExternalSearchIndexSpecified
        {
            get
            {
                return this.canEnableSyncToExternalSearchIndexFieldSpecified;
            }
            set
            {
                this.canEnableSyncToExternalSearchIndexFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte EnforceStateTransitions
        {
            get
            {
                return this.enforceStateTransitionsField;
            }
            set
            {
                this.enforceStateTransitionsField = value;
            }
        }

        /// <remarks/>
        public byte CanChangeHierarchicalRelationship
        {
            get
            {
                return this.canChangeHierarchicalRelationshipField;
            }
            set
            {
                this.canChangeHierarchicalRelationshipField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanChangeHierarchicalRelationshipSpecified
        {
            get
            {
                return this.canChangeHierarchicalRelationshipFieldSpecified;
            }
            set
            {
                this.canChangeHierarchicalRelationshipFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte EntityHelpUrlEnabled
        {
            get
            {
                return this.entityHelpUrlEnabledField;
            }
            set
            {
                this.entityHelpUrlEnabledField = value;
            }
        }

        /// <remarks/>
        public byte ChangeTrackingEnabled
        {
            get
            {
                return this.changeTrackingEnabledField;
            }
            set
            {
                this.changeTrackingEnabledField = value;
            }
        }

        /// <remarks/>
        public byte CanChangeTrackingBeEnabled
        {
            get
            {
                return this.canChangeTrackingBeEnabledField;
            }
            set
            {
                this.canChangeTrackingBeEnabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanChangeTrackingBeEnabledSpecified
        {
            get
            {
                return this.canChangeTrackingBeEnabledFieldSpecified;
            }
            set
            {
                this.canChangeTrackingBeEnabledFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte IsEnabledForExternalChannels
        {
            get
            {
                return this.isEnabledForExternalChannelsField;
            }
            set
            {
                this.isEnabledForExternalChannelsField = value;
            }
        }

        /// <remarks/>
        public byte IsSolutionAware
        {
            get
            {
                return this.isSolutionAwareField;
            }
            set
            {
                this.isSolutionAwareField = value;
            }
        }

        /// <remarks/>
        public string HasRelatedNotes
        {
            get
            {
                return this.hasRelatedNotesField;
            }
            set
            {
                this.hasRelatedNotesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityLocalizedNames
    {

        private ImportExportXmlEntityEntityInfoEntityLocalizedNamesLocalizedName localizedNameField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityLocalizedNamesLocalizedName LocalizedName
        {
            get
            {
                return this.localizedNameField;
            }
            set
            {
                this.localizedNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityLocalizedNamesLocalizedName
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityLocalizedCollectionNames
    {

        private ImportExportXmlEntityEntityInfoEntityLocalizedCollectionNamesLocalizedCollectionName localizedCollectionNameField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityLocalizedCollectionNamesLocalizedCollectionName LocalizedCollectionName
        {
            get
            {
                return this.localizedCollectionNameField;
            }
            set
            {
                this.localizedCollectionNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityLocalizedCollectionNamesLocalizedCollectionName
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityDescriptions
    {

        private ImportExportXmlEntityEntityInfoEntityDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityDescriptionsDescription
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttribute
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private string physicalNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AppDefaultValue", typeof(uint))]
        [System.Xml.Serialization.XmlElementAttribute("AutoNumberFormat", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("Behavior", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("CanChangeDateTimeBehavior", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("CanModifyAdditionalSettings", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("CanModifyGlobalFilterSettings", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("CanModifyIsSortableSettings", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("CanModifyRequirementLevelSettings", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("CanModifySearchSettings", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("Descriptions", typeof(ImportExportXmlEntityEntityInfoEntityAttributeDescriptions))]
        [System.Xml.Serialization.XmlElementAttribute("DisplayMask", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Format", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("FormulaDefinitionFileName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ImeMode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("IntroducedVersion", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("IsAuditEnabled", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsCustomField", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsCustomizable", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsDataSourceSecret", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsFilterable", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsGlobalFilterEnabled", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsLocalizable", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsLogical", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsRenameable", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsRetrievable", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsSearchable", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsSecured", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("IsSortableEnabled", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("Length", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("LogicalName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("LookupStyle", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("LookupTypes", typeof(ImportExportXmlEntityEntityInfoEntityAttributeLookupTypes))]
        [System.Xml.Serialization.XmlElementAttribute("MaxLength", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("MaxValue", typeof(uint))]
        [System.Xml.Serialization.XmlElementAttribute("MinValue", typeof(int))]
        [System.Xml.Serialization.XmlElementAttribute("Name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("OptionSetName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("RequiredLevel", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("SourceType", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("Type", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ValidForCreateApi", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("ValidForReadApi", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("ValidForUpdateApi", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("displaynames", typeof(ImportExportXmlEntityEntityInfoEntityAttributeDisplaynames))]
        [System.Xml.Serialization.XmlElementAttribute("optionset", typeof(ImportExportXmlEntityEntityInfoEntityAttributeOptionset))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PhysicalName
        {
            get
            {
                return this.physicalNameField;
            }
            set
            {
                this.physicalNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeDescriptions
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeDescriptionsDescription
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeLookupTypes
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeLookupTypesLookupType[] lookupTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LookupType")]
        public ImportExportXmlEntityEntityInfoEntityAttributeLookupTypesLookupType[] LookupType
        {
            get
            {
                return this.lookupTypeField;
            }
            set
            {
                this.lookupTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeLookupTypesLookupType
    {

        private string idField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeDisplaynames
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeDisplaynamesDisplayname displaynameField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeDisplaynamesDisplayname displayname
        {
            get
            {
                return this.displaynameField;
            }
            set
            {
                this.displaynameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeDisplaynamesDisplayname
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionset
    {

        private string optionSetTypeField;

        private string introducedVersionField;

        private byte isCustomizableField;

        private bool isCustomizableFieldSpecified;

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDisplaynames displaynamesField;

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDescriptions descriptionsField;

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOption[] optionsField;

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatus[] statusesField;

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetState[] statesField;

        private string nameField;

        /// <remarks/>
        public string OptionSetType
        {
            get
            {
                return this.optionSetTypeField;
            }
            set
            {
                this.optionSetTypeField = value;
            }
        }

        /// <remarks/>
        public string IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        public byte IsCustomizable
        {
            get
            {
                return this.isCustomizableField;
            }
            set
            {
                this.isCustomizableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsCustomizableSpecified
        {
            get
            {
                return this.isCustomizableFieldSpecified;
            }
            set
            {
                this.isCustomizableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDisplaynames displaynames
        {
            get
            {
                return this.displaynamesField;
            }
            set
            {
                this.displaynamesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDescriptions Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("option", IsNullable = false)]
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOption[] options
        {
            get
            {
                return this.optionsField;
            }
            set
            {
                this.optionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("status", IsNullable = false)]
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatus[] statuses
        {
            get
            {
                return this.statusesField;
            }
            set
            {
                this.statusesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("state", IsNullable = false)]
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetState[] states
        {
            get
            {
                return this.statesField;
            }
            set
            {
                this.statesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDisplaynames
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDisplaynamesDisplayname displaynameField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDisplaynamesDisplayname displayname
        {
            get
            {
                return this.displaynameField;
            }
            set
            {
                this.displaynameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDisplaynamesDisplayname
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDescriptions
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetDescriptionsDescription
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOption
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOptionLabels labelsField;

        private byte valueField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOptionLabels labels
        {
            get
            {
                return this.labelsField;
            }
            set
            {
                this.labelsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOptionLabels
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOptionLabelsLabel labelField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOptionLabelsLabel label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetOptionLabelsLabel
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatus
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatusLabels labelsField;

        private byte valueField;

        private byte stateField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatusLabels labels
        {
            get
            {
                return this.labelsField;
            }
            set
            {
                this.labelsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatusLabels
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatusLabelsLabel labelField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatusLabelsLabel label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStatusLabelsLabel
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetState
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStateLabels labelsField;

        private byte valueField;

        private byte defaultstatusField;

        private string invariantnameField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStateLabels labels
        {
            get
            {
                return this.labelsField;
            }
            set
            {
                this.labelsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte defaultstatus
        {
            get
            {
                return this.defaultstatusField;
            }
            set
            {
                this.defaultstatusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string invariantname
        {
            get
            {
                return this.invariantnameField;
            }
            set
            {
                this.invariantnameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStateLabels
    {

        private ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStateLabelsLabel labelField;

        /// <remarks/>
        public ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStateLabelsLabel label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityEntityInfoEntityAttributeOptionsetStateLabelsLabel
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        AppDefaultValue,

        /// <remarks/>
        AutoNumberFormat,

        /// <remarks/>
        Behavior,

        /// <remarks/>
        CanChangeDateTimeBehavior,

        /// <remarks/>
        CanModifyAdditionalSettings,

        /// <remarks/>
        CanModifyGlobalFilterSettings,

        /// <remarks/>
        CanModifyIsSortableSettings,

        /// <remarks/>
        CanModifyRequirementLevelSettings,

        /// <remarks/>
        CanModifySearchSettings,

        /// <remarks/>
        Descriptions,

        /// <remarks/>
        DisplayMask,

        /// <remarks/>
        Format,

        /// <remarks/>
        FormulaDefinitionFileName,

        /// <remarks/>
        ImeMode,

        /// <remarks/>
        IntroducedVersion,

        /// <remarks/>
        IsAuditEnabled,

        /// <remarks/>
        IsCustomField,

        /// <remarks/>
        IsCustomizable,

        /// <remarks/>
        IsDataSourceSecret,

        /// <remarks/>
        IsFilterable,

        /// <remarks/>
        IsGlobalFilterEnabled,

        /// <remarks/>
        IsLocalizable,

        /// <remarks/>
        IsLogical,

        /// <remarks/>
        IsRenameable,

        /// <remarks/>
        IsRetrievable,

        /// <remarks/>
        IsSearchable,

        /// <remarks/>
        IsSecured,

        /// <remarks/>
        IsSortableEnabled,

        /// <remarks/>
        Length,

        /// <remarks/>
        LogicalName,

        /// <remarks/>
        LookupStyle,

        /// <remarks/>
        LookupTypes,

        /// <remarks/>
        MaxLength,

        /// <remarks/>
        MaxValue,

        /// <remarks/>
        MinValue,

        /// <remarks/>
        Name,

        /// <remarks/>
        OptionSetName,

        /// <remarks/>
        RequiredLevel,

        /// <remarks/>
        SourceType,

        /// <remarks/>
        Type,

        /// <remarks/>
        ValidForCreateApi,

        /// <remarks/>
        ValidForReadApi,

        /// <remarks/>
        ValidForUpdateApi,

        /// <remarks/>
        displaynames,

        /// <remarks/>
        optionset,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityForms
    {

        private ImportExportXmlEntityFormsSystemform systemformField;

        private string typeField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemform systemform
        {
            get
            {
                return this.systemformField;
            }
            set
            {
                this.systemformField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemform
    {

        private string formidField;

        private string introducedVersionField;

        private byte formPresentationField;

        private byte formActivationStateField;

        private ImportExportXmlEntityFormsSystemformForm formField;

        private byte isCustomizableField;

        private bool isCustomizableFieldSpecified;

        private byte canBeDeletedField;

        private bool canBeDeletedFieldSpecified;

        private ImportExportXmlEntityFormsSystemformLocalizedNames localizedNamesField;

        private ImportExportXmlEntityFormsSystemformDescriptions descriptionsField;

        /// <remarks/>
        public string formid
        {
            get
            {
                return this.formidField;
            }
            set
            {
                this.formidField = value;
            }
        }

        /// <remarks/>
        public string IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        public byte FormPresentation
        {
            get
            {
                return this.formPresentationField;
            }
            set
            {
                this.formPresentationField = value;
            }
        }

        /// <remarks/>
        public byte FormActivationState
        {
            get
            {
                return this.formActivationStateField;
            }
            set
            {
                this.formActivationStateField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformForm form
        {
            get
            {
                return this.formField;
            }
            set
            {
                this.formField = value;
            }
        }

        /// <remarks/>
        public byte IsCustomizable
        {
            get
            {
                return this.isCustomizableField;
            }
            set
            {
                this.isCustomizableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsCustomizableSpecified
        {
            get
            {
                return this.isCustomizableFieldSpecified;
            }
            set
            {
                this.isCustomizableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanBeDeleted
        {
            get
            {
                return this.canBeDeletedField;
            }
            set
            {
                this.canBeDeletedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanBeDeletedSpecified
        {
            get
            {
                return this.canBeDeletedFieldSpecified;
            }
            set
            {
                this.canBeDeletedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformLocalizedNames LocalizedNames
        {
            get
            {
                return this.localizedNamesField;
            }
            set
            {
                this.localizedNamesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformDescriptions Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformForm
    {

        private ImportExportXmlEntityFormsSystemformFormTabs tabsField;

        private ImportExportXmlEntityFormsSystemformFormHeader headerField;

        private ImportExportXmlEntityFormsSystemformFormFooter footerField;

        private string headerdensityField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabs tabs
        {
            get
            {
                return this.tabsField;
            }
            set
            {
                this.tabsField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormHeader header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormFooter footer
        {
            get
            {
                return this.footerField;
            }
            set
            {
                this.footerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string headerdensity
        {
            get
            {
                return this.headerdensityField;
            }
            set
            {
                this.headerdensityField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabs
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTab tabField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTab tab
        {
            get
            {
                return this.tabField;
            }
            set
            {
                this.tabField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTab
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTabLabels labelsField;

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumn[] columnsField;

        private bool verticallayoutField;

        private string idField;

        private byte isUserDefinedField;

        private byte ordinalvalueField;

        private bool ordinalvalueFieldSpecified;

        private string nameField;

        private string labelidField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTabLabels labels
        {
            get
            {
                return this.labelsField;
            }
            set
            {
                this.labelsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false)]
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumn[] columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool verticallayout
        {
            get
            {
                return this.verticallayoutField;
            }
            set
            {
                this.verticallayoutField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte IsUserDefined
        {
            get
            {
                return this.isUserDefinedField;
            }
            set
            {
                this.isUserDefinedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ordinalvalue
        {
            get
            {
                return this.ordinalvalueField;
            }
            set
            {
                this.ordinalvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ordinalvalueSpecified
        {
            get
            {
                return this.ordinalvalueFieldSpecified;
            }
            set
            {
                this.ordinalvalueFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string labelid
        {
            get
            {
                return this.labelidField;
            }
            set
            {
                this.labelidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabLabels
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTabLabelsLabel labelField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTabLabelsLabel label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabLabelsLabel
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumn
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumnSection[] sectionsField;

        private string widthField;

        private byte idField;

        private bool idFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("section", IsNullable = false)]
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumnSection[] sections
        {
            get
            {
                return this.sectionsField;
            }
            set
            {
                this.sectionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumnSection
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionLabels labelsField;

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCell[][] rowsField;

        private bool showlabelField;

        private bool showbarField;

        private byte isUserDefinedField;

        private string idField;

        private byte ordinalvalueField;

        private bool ordinalvalueFieldSpecified;

        private string nameField;

        private ushort columnsField;

        private bool columnsFieldSpecified;

        private string labelidField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionLabels labels
        {
            get
            {
                return this.labelsField;
            }
            set
            {
                this.labelsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("cell", IsNullable = false, NestingLevel = 1)]
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCell[][] rows
        {
            get
            {
                return this.rowsField;
            }
            set
            {
                this.rowsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showbar
        {
            get
            {
                return this.showbarField;
            }
            set
            {
                this.showbarField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte IsUserDefined
        {
            get
            {
                return this.isUserDefinedField;
            }
            set
            {
                this.isUserDefinedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ordinalvalue
        {
            get
            {
                return this.ordinalvalueField;
            }
            set
            {
                this.ordinalvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ordinalvalueSpecified
        {
            get
            {
                return this.ordinalvalueFieldSpecified;
            }
            set
            {
                this.ordinalvalueFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool columnsSpecified
        {
            get
            {
                return this.columnsFieldSpecified;
            }
            set
            {
                this.columnsFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string labelid
        {
            get
            {
                return this.labelidField;
            }
            set
            {
                this.labelidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionLabels
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionLabelsLabel labelField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionLabelsLabel label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionLabelsLabel
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCell
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellLabels labelsField;

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellControl controlField;

        private string idField;

        private ushort ordinalvalueField;

        private bool ordinalvalueFieldSpecified;

        private bool showlabelField;

        private bool showlabelFieldSpecified;

        private byte locklevelField;

        private bool locklevelFieldSpecified;

        private string labelidField;

        private bool autoField;

        private bool autoFieldSpecified;

        private byte rowspanField;

        private bool rowspanFieldSpecified;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellLabels labels
        {
            get
            {
                return this.labelsField;
            }
            set
            {
                this.labelsField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellControl control
        {
            get
            {
                return this.controlField;
            }
            set
            {
                this.controlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ordinalvalue
        {
            get
            {
                return this.ordinalvalueField;
            }
            set
            {
                this.ordinalvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ordinalvalueSpecified
        {
            get
            {
                return this.ordinalvalueFieldSpecified;
            }
            set
            {
                this.ordinalvalueFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool showlabelSpecified
        {
            get
            {
                return this.showlabelFieldSpecified;
            }
            set
            {
                this.showlabelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte locklevel
        {
            get
            {
                return this.locklevelField;
            }
            set
            {
                this.locklevelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool locklevelSpecified
        {
            get
            {
                return this.locklevelFieldSpecified;
            }
            set
            {
                this.locklevelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string labelid
        {
            get
            {
                return this.labelidField;
            }
            set
            {
                this.labelidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool auto
        {
            get
            {
                return this.autoField;
            }
            set
            {
                this.autoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool autoSpecified
        {
            get
            {
                return this.autoFieldSpecified;
            }
            set
            {
                this.autoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte rowspan
        {
            get
            {
                return this.rowspanField;
            }
            set
            {
                this.rowspanField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rowspanSpecified
        {
            get
            {
                return this.rowspanFieldSpecified;
            }
            set
            {
                this.rowspanFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellLabels
    {

        private ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellLabelsLabel labelField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellLabelsLabel label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellLabelsLabel
    {

        private string descriptionField;

        private ushort languagecodeField;

        private string solutionactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string solutionaction
        {
            get
            {
                return this.solutionactionField;
            }
            set
            {
                this.solutionactionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormTabsTabColumnSectionRowCellControl
    {

        private string idField;

        private string classidField;

        private string datafieldnameField;

        private bool disabledField;

        private bool disabledFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string classid
        {
            get
            {
                return this.classidField;
            }
            set
            {
                this.classidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string datafieldname
        {
            get
            {
                return this.datafieldnameField;
            }
            set
            {
                this.datafieldnameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool disabled
        {
            get
            {
                return this.disabledField;
            }
            set
            {
                this.disabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool disabledSpecified
        {
            get
            {
                return this.disabledFieldSpecified;
            }
            set
            {
                this.disabledFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormHeader
    {

        private ImportExportXmlEntityFormsSystemformFormHeaderRows rowsField;

        private string idField;

        private string celllabelpositionField;

        private byte columnsField;

        private byte labelwidthField;

        private string celllabelalignmentField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormHeaderRows rows
        {
            get
            {
                return this.rowsField;
            }
            set
            {
                this.rowsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string celllabelposition
        {
            get
            {
                return this.celllabelpositionField;
            }
            set
            {
                this.celllabelpositionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte labelwidth
        {
            get
            {
                return this.labelwidthField;
            }
            set
            {
                this.labelwidthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string celllabelalignment
        {
            get
            {
                return this.celllabelalignmentField;
            }
            set
            {
                this.celllabelalignmentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormHeaderRows
    {

        private ImportExportXmlEntityFormsSystemformFormHeaderRowsCell[] rowField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("cell", IsNullable = false)]
        public ImportExportXmlEntityFormsSystemformFormHeaderRowsCell[] row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormHeaderRowsCell
    {

        private string idField;

        private bool showlabelField;

        private string labelidField;

        private ushort ordinalvalueField;

        private string solutionactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string labelid
        {
            get
            {
                return this.labelidField;
            }
            set
            {
                this.labelidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ordinalvalue
        {
            get
            {
                return this.ordinalvalueField;
            }
            set
            {
                this.ordinalvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string solutionaction
        {
            get
            {
                return this.solutionactionField;
            }
            set
            {
                this.solutionactionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormFooter
    {

        private ImportExportXmlEntityFormsSystemformFormFooterRows rowsField;

        private string idField;

        private string celllabelpositionField;

        private byte columnsField;

        private byte labelwidthField;

        private string celllabelalignmentField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformFormFooterRows rows
        {
            get
            {
                return this.rowsField;
            }
            set
            {
                this.rowsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string celllabelposition
        {
            get
            {
                return this.celllabelpositionField;
            }
            set
            {
                this.celllabelpositionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte labelwidth
        {
            get
            {
                return this.labelwidthField;
            }
            set
            {
                this.labelwidthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string celllabelalignment
        {
            get
            {
                return this.celllabelalignmentField;
            }
            set
            {
                this.celllabelalignmentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormFooterRows
    {

        private ImportExportXmlEntityFormsSystemformFormFooterRowsCell[] rowField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("cell", IsNullable = false)]
        public ImportExportXmlEntityFormsSystemformFormFooterRowsCell[] row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformFormFooterRowsCell
    {

        private string idField;

        private bool showlabelField;

        private string labelidField;

        private ushort ordinalvalueField;

        private string solutionactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string labelid
        {
            get
            {
                return this.labelidField;
            }
            set
            {
                this.labelidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ordinalvalue
        {
            get
            {
                return this.ordinalvalueField;
            }
            set
            {
                this.ordinalvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string solutionaction
        {
            get
            {
                return this.solutionactionField;
            }
            set
            {
                this.solutionactionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformLocalizedNames
    {

        private ImportExportXmlEntityFormsSystemformLocalizedNamesLocalizedName localizedNameField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformLocalizedNamesLocalizedName LocalizedName
        {
            get
            {
                return this.localizedNameField;
            }
            set
            {
                this.localizedNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformLocalizedNamesLocalizedName
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformDescriptions
    {

        private ImportExportXmlEntityFormsSystemformDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlEntityFormsSystemformDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityFormsSystemformDescriptionsDescription
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueries
    {

        private ImportExportXmlEntitySavedQueriesSavedquery[] savedqueriesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("savedquery", IsNullable = false)]
        public ImportExportXmlEntitySavedQueriesSavedquery[] savedqueries
        {
            get
            {
                return this.savedqueriesField;
            }
            set
            {
                this.savedqueriesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedquery
    {

        private byte isCustomizableField;

        private bool isCustomizableFieldSpecified;

        private byte canBeDeletedField;

        private bool canBeDeletedFieldSpecified;

        private byte isquickfindqueryField;

        private byte isprivateField;

        private byte isdefaultField;

        private string savedqueryidField;

        private ImportExportXmlEntitySavedQueriesSavedqueryLayoutxml layoutxmlField;

        private ushort querytypeField;

        private ImportExportXmlEntitySavedQueriesSavedqueryFetchxml fetchxmlField;

        private string introducedVersionField;

        private ImportExportXmlEntitySavedQueriesSavedqueryLocalizedNames localizedNamesField;

        private ImportExportXmlEntitySavedQueriesSavedqueryDescriptions descriptionsField;

        /// <remarks/>
        public byte IsCustomizable
        {
            get
            {
                return this.isCustomizableField;
            }
            set
            {
                this.isCustomizableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsCustomizableSpecified
        {
            get
            {
                return this.isCustomizableFieldSpecified;
            }
            set
            {
                this.isCustomizableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CanBeDeleted
        {
            get
            {
                return this.canBeDeletedField;
            }
            set
            {
                this.canBeDeletedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CanBeDeletedSpecified
        {
            get
            {
                return this.canBeDeletedFieldSpecified;
            }
            set
            {
                this.canBeDeletedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte isquickfindquery
        {
            get
            {
                return this.isquickfindqueryField;
            }
            set
            {
                this.isquickfindqueryField = value;
            }
        }

        /// <remarks/>
        public byte isprivate
        {
            get
            {
                return this.isprivateField;
            }
            set
            {
                this.isprivateField = value;
            }
        }

        /// <remarks/>
        public byte isdefault
        {
            get
            {
                return this.isdefaultField;
            }
            set
            {
                this.isdefaultField = value;
            }
        }

        /// <remarks/>
        public string savedqueryid
        {
            get
            {
                return this.savedqueryidField;
            }
            set
            {
                this.savedqueryidField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryLayoutxml layoutxml
        {
            get
            {
                return this.layoutxmlField;
            }
            set
            {
                this.layoutxmlField = value;
            }
        }

        /// <remarks/>
        public ushort querytype
        {
            get
            {
                return this.querytypeField;
            }
            set
            {
                this.querytypeField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryFetchxml fetchxml
        {
            get
            {
                return this.fetchxmlField;
            }
            set
            {
                this.fetchxmlField = value;
            }
        }

        /// <remarks/>
        public string IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryLocalizedNames LocalizedNames
        {
            get
            {
                return this.localizedNamesField;
            }
            set
            {
                this.localizedNamesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryDescriptions Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryLayoutxml
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGrid gridField;

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGrid grid
        {
            get
            {
                return this.gridField;
            }
            set
            {
                this.gridField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGrid
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGridRow rowField;

        private string nameField;

        private string jumpField;

        private byte selectField;

        private byte iconField;

        private byte previewField;

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGridRow row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string jump
        {
            get
            {
                return this.jumpField;
            }
            set
            {
                this.jumpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte select
        {
            get
            {
                return this.selectField;
            }
            set
            {
                this.selectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte icon
        {
            get
            {
                return this.iconField;
            }
            set
            {
                this.iconField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte preview
        {
            get
            {
                return this.previewField;
            }
            set
            {
                this.previewField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGridRow
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGridRowCell[] cellField;

        private string nameField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("cell")]
        public ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGridRowCell[] cell
        {
            get
            {
                return this.cellField;
            }
            set
            {
                this.cellField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryLayoutxmlGridRowCell
    {

        private string nameField;

        private ushort widthField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryFetchxml
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetch fetchField;

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetch fetch
        {
            get
            {
                return this.fetchField;
            }
            set
            {
                this.fetchField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetch
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntity entityField;

        private decimal versionField;

        private string mappingField;

        private string outputformatField;

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntity entity
        {
            get
            {
                return this.entityField;
            }
            set
            {
                this.entityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mapping
        {
            get
            {
                return this.mappingField;
            }
            set
            {
                this.mappingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("output-format")]
        public string outputformat
        {
            get
            {
                return this.outputformatField;
            }
            set
            {
                this.outputformatField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntity
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityAttribute[] attributeField;

        private ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityOrder orderField;

        private ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityFilter[] filterField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityAttribute[] attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityOrder order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("filter")]
        public ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityFilter[] filter
        {
            get
            {
                return this.filterField;
            }
            set
            {
                this.filterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityAttribute
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityOrder
    {

        private string attributeField;

        private bool descendingField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool descending
        {
            get
            {
                return this.descendingField;
            }
            set
            {
                this.descendingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityFilter
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityFilterCondition[] conditionField;

        private string typeField;

        private byte isquickfindfieldsField;

        private bool isquickfindfieldsFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("condition")]
        public ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityFilterCondition[] condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte isquickfindfields
        {
            get
            {
                return this.isquickfindfieldsField;
            }
            set
            {
                this.isquickfindfieldsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool isquickfindfieldsSpecified
        {
            get
            {
                return this.isquickfindfieldsFieldSpecified;
            }
            set
            {
                this.isquickfindfieldsFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryFetchxmlFetchEntityFilterCondition
    {

        private string attributeField;

        private string operatorField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @operator
        {
            get
            {
                return this.operatorField;
            }
            set
            {
                this.operatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryLocalizedNames
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryLocalizedNamesLocalizedName localizedNameField;

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryLocalizedNamesLocalizedName LocalizedName
        {
            get
            {
                return this.localizedNameField;
            }
            set
            {
                this.localizedNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryLocalizedNamesLocalizedName
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryDescriptions
    {

        private ImportExportXmlEntitySavedQueriesSavedqueryDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlEntitySavedQueriesSavedqueryDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntitySavedQueriesSavedqueryDescriptionsDescription
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRibbonDiffXml
    {

        private object customActionsField;

        private ImportExportXmlEntityRibbonDiffXmlTemplates templatesField;

        private object commandDefinitionsField;

        private ImportExportXmlEntityRibbonDiffXmlRuleDefinitions ruleDefinitionsField;

        private object locLabelsField;

        /// <remarks/>
        public object CustomActions
        {
            get
            {
                return this.customActionsField;
            }
            set
            {
                this.customActionsField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityRibbonDiffXmlTemplates Templates
        {
            get
            {
                return this.templatesField;
            }
            set
            {
                this.templatesField = value;
            }
        }

        /// <remarks/>
        public object CommandDefinitions
        {
            get
            {
                return this.commandDefinitionsField;
            }
            set
            {
                this.commandDefinitionsField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityRibbonDiffXmlRuleDefinitions RuleDefinitions
        {
            get
            {
                return this.ruleDefinitionsField;
            }
            set
            {
                this.ruleDefinitionsField = value;
            }
        }

        /// <remarks/>
        public object LocLabels
        {
            get
            {
                return this.locLabelsField;
            }
            set
            {
                this.locLabelsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRibbonDiffXmlTemplates
    {

        private ImportExportXmlEntityRibbonDiffXmlTemplatesRibbonTemplates ribbonTemplatesField;

        /// <remarks/>
        public ImportExportXmlEntityRibbonDiffXmlTemplatesRibbonTemplates RibbonTemplates
        {
            get
            {
                return this.ribbonTemplatesField;
            }
            set
            {
                this.ribbonTemplatesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRibbonDiffXmlTemplatesRibbonTemplates
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRibbonDiffXmlRuleDefinitions
    {

        private object tabDisplayRulesField;

        private object displayRulesField;

        private object enableRulesField;

        /// <remarks/>
        public object TabDisplayRules
        {
            get
            {
                return this.tabDisplayRulesField;
            }
            set
            {
                this.tabDisplayRulesField = value;
            }
        }

        /// <remarks/>
        public object DisplayRules
        {
            get
            {
                return this.displayRulesField;
            }
            set
            {
                this.displayRulesField = value;
            }
        }

        /// <remarks/>
        public object EnableRules
        {
            get
            {
                return this.enableRulesField;
            }
            set
            {
                this.enableRulesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlRoles
    {

        private ImportExportXmlRolesRole roleField;

        /// <remarks/>
        public ImportExportXmlRolesRole Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlRolesRole
    {

        private ImportExportXmlRolesRoleRolePrivilege[] rolePrivilegesField;

        private string idField;

        private string nameField;

        private byte isinheritedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("RolePrivilege", IsNullable = false)]
        public ImportExportXmlRolesRoleRolePrivilege[] RolePrivileges
        {
            get
            {
                return this.rolePrivilegesField;
            }
            set
            {
                this.rolePrivilegesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte isinherited
        {
            get
            {
                return this.isinheritedField;
            }
            set
            {
                this.isinheritedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlRolesRoleRolePrivilege
    {

        private string nameField;

        private string levelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlWorkflow
    {

        private string jsonFileNameField;

        private byte typeField;

        private byte subprocessField;

        private byte categoryField;

        private byte modeField;

        private byte scopeField;

        private byte onDemandField;

        private byte triggerOnCreateField;

        private byte triggerOnDeleteField;

        private byte asyncAutodeleteField;

        private byte syncWorkflowLogOnFailureField;

        private byte stateCodeField;

        private byte statusCodeField;

        private byte runAsField;

        private byte isTransactedField;

        private string introducedVersionField;

        private byte isCustomizableField;

        private bool isCustomizableFieldSpecified;

        private byte businessProcessTypeField;

        private bool businessProcessTypeFieldSpecified;

        private byte isCustomProcessingStepAllowedForOtherPublishersField;

        private string primaryEntityField;

        private ImportExportXmlWorkflowLocalizedNames localizedNamesField;

        private ImportExportXmlWorkflowDescriptions descriptionsField;

        private string workflowIdField;

        private string nameField;

        private string descriptionField;

        /// <remarks/>
        public string JsonFileName
        {
            get
            {
                return this.jsonFileNameField;
            }
            set
            {
                this.jsonFileNameField = value;
            }
        }

        /// <remarks/>
        public byte Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte Subprocess
        {
            get
            {
                return this.subprocessField;
            }
            set
            {
                this.subprocessField = value;
            }
        }

        /// <remarks/>
        public byte Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        public byte Mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }

        /// <remarks/>
        public byte Scope
        {
            get
            {
                return this.scopeField;
            }
            set
            {
                this.scopeField = value;
            }
        }

        /// <remarks/>
        public byte OnDemand
        {
            get
            {
                return this.onDemandField;
            }
            set
            {
                this.onDemandField = value;
            }
        }

        /// <remarks/>
        public byte TriggerOnCreate
        {
            get
            {
                return this.triggerOnCreateField;
            }
            set
            {
                this.triggerOnCreateField = value;
            }
        }

        /// <remarks/>
        public byte TriggerOnDelete
        {
            get
            {
                return this.triggerOnDeleteField;
            }
            set
            {
                this.triggerOnDeleteField = value;
            }
        }

        /// <remarks/>
        public byte AsyncAutodelete
        {
            get
            {
                return this.asyncAutodeleteField;
            }
            set
            {
                this.asyncAutodeleteField = value;
            }
        }

        /// <remarks/>
        public byte SyncWorkflowLogOnFailure
        {
            get
            {
                return this.syncWorkflowLogOnFailureField;
            }
            set
            {
                this.syncWorkflowLogOnFailureField = value;
            }
        }

        /// <remarks/>
        public byte StateCode
        {
            get
            {
                return this.stateCodeField;
            }
            set
            {
                this.stateCodeField = value;
            }
        }

        /// <remarks/>
        public byte StatusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }

        /// <remarks/>
        public byte RunAs
        {
            get
            {
                return this.runAsField;
            }
            set
            {
                this.runAsField = value;
            }
        }

        /// <remarks/>
        public byte IsTransacted
        {
            get
            {
                return this.isTransactedField;
            }
            set
            {
                this.isTransactedField = value;
            }
        }

        /// <remarks/>
        public string IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        public byte IsCustomizable
        {
            get
            {
                return this.isCustomizableField;
            }
            set
            {
                this.isCustomizableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsCustomizableSpecified
        {
            get
            {
                return this.isCustomizableFieldSpecified;
            }
            set
            {
                this.isCustomizableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte BusinessProcessType
        {
            get
            {
                return this.businessProcessTypeField;
            }
            set
            {
                this.businessProcessTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BusinessProcessTypeSpecified
        {
            get
            {
                return this.businessProcessTypeFieldSpecified;
            }
            set
            {
                this.businessProcessTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte IsCustomProcessingStepAllowedForOtherPublishers
        {
            get
            {
                return this.isCustomProcessingStepAllowedForOtherPublishersField;
            }
            set
            {
                this.isCustomProcessingStepAllowedForOtherPublishersField = value;
            }
        }

        /// <remarks/>
        public string PrimaryEntity
        {
            get
            {
                return this.primaryEntityField;
            }
            set
            {
                this.primaryEntityField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlWorkflowLocalizedNames LocalizedNames
        {
            get
            {
                return this.localizedNamesField;
            }
            set
            {
                this.localizedNamesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlWorkflowDescriptions Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string WorkflowId
        {
            get
            {
                return this.workflowIdField;
            }
            set
            {
                this.workflowIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlWorkflowLocalizedNames
    {

        private ImportExportXmlWorkflowLocalizedNamesLocalizedName localizedNameField;

        /// <remarks/>
        public ImportExportXmlWorkflowLocalizedNamesLocalizedName LocalizedName
        {
            get
            {
                return this.localizedNameField;
            }
            set
            {
                this.localizedNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlWorkflowLocalizedNamesLocalizedName
    {

        private ushort languagecodeField;

        private string descriptionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlWorkflowDescriptions
    {

        private ImportExportXmlWorkflowDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlWorkflowDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlWorkflowDescriptionsDescription
    {

        private ushort languagecodeField;

        private string descriptionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlFieldSecurityProfiles
    {

        private ImportExportXmlFieldSecurityProfilesFieldSecurityProfile fieldSecurityProfileField;

        /// <remarks/>
        public ImportExportXmlFieldSecurityProfilesFieldSecurityProfile FieldSecurityProfile
        {
            get
            {
                return this.fieldSecurityProfileField;
            }
            set
            {
                this.fieldSecurityProfileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlFieldSecurityProfilesFieldSecurityProfile
    {

        private ImportExportXmlFieldSecurityProfilesFieldSecurityProfileFieldPermissions fieldPermissionsField;

        private string nameField;

        private string fieldsecurityprofileidField;

        /// <remarks/>
        public ImportExportXmlFieldSecurityProfilesFieldSecurityProfileFieldPermissions FieldPermissions
        {
            get
            {
                return this.fieldPermissionsField;
            }
            set
            {
                this.fieldPermissionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fieldsecurityprofileid
        {
            get
            {
                return this.fieldsecurityprofileidField;
            }
            set
            {
                this.fieldsecurityprofileidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlFieldSecurityProfilesFieldSecurityProfileFieldPermissions
    {

        private ImportExportXmlFieldSecurityProfilesFieldSecurityProfileFieldPermissionsFieldPermission fieldPermissionField;

        /// <remarks/>
        public ImportExportXmlFieldSecurityProfilesFieldSecurityProfileFieldPermissionsFieldPermission FieldPermission
        {
            get
            {
                return this.fieldPermissionField;
            }
            set
            {
                this.fieldPermissionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlFieldSecurityProfilesFieldSecurityProfileFieldPermissionsFieldPermission
    {

        private string entityNameField;

        private string attributeNameField;

        private byte canReadField;

        private byte canUpdateField;

        private byte canCreateField;

        /// <remarks/>
        public string EntityName
        {
            get
            {
                return this.entityNameField;
            }
            set
            {
                this.entityNameField = value;
            }
        }

        /// <remarks/>
        public string AttributeName
        {
            get
            {
                return this.attributeNameField;
            }
            set
            {
                this.attributeNameField = value;
            }
        }

        /// <remarks/>
        public byte CanRead
        {
            get
            {
                return this.canReadField;
            }
            set
            {
                this.canReadField = value;
            }
        }

        /// <remarks/>
        public byte CanUpdate
        {
            get
            {
                return this.canUpdateField;
            }
            set
            {
                this.canUpdateField = value;
            }
        }

        /// <remarks/>
        public byte CanCreate
        {
            get
            {
                return this.canCreateField;
            }
            set
            {
                this.canCreateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRelationship
    {

        private string entityRelationshipTypeField;

        private byte isCustomizableField;

        private bool isCustomizableFieldSpecified;

        private string introducedVersionField;

        private byte isHierarchicalField;

        private string referencingEntityNameField;

        private string referencedEntityNameField;

        private string cascadeAssignField;

        private string cascadeDeleteField;

        private string cascadeReparentField;

        private string cascadeShareField;

        private string cascadeUnshareField;

        private string cascadeRollupViewField;

        private byte isValidForAdvancedFindField;

        private bool isValidForAdvancedFindFieldSpecified;

        private string referencingAttributeNameField;

        private ImportExportXmlEntityRelationshipRelationshipDescription relationshipDescriptionField;

        private ImportExportXmlEntityRelationshipEntityRelationshipRole[] entityRelationshipRolesField;

        private string nameField;

        /// <remarks/>
        public string EntityRelationshipType
        {
            get
            {
                return this.entityRelationshipTypeField;
            }
            set
            {
                this.entityRelationshipTypeField = value;
            }
        }

        /// <remarks/>
        public byte IsCustomizable
        {
            get
            {
                return this.isCustomizableField;
            }
            set
            {
                this.isCustomizableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsCustomizableSpecified
        {
            get
            {
                return this.isCustomizableFieldSpecified;
            }
            set
            {
                this.isCustomizableFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        public byte IsHierarchical
        {
            get
            {
                return this.isHierarchicalField;
            }
            set
            {
                this.isHierarchicalField = value;
            }
        }

        /// <remarks/>
        public string ReferencingEntityName
        {
            get
            {
                return this.referencingEntityNameField;
            }
            set
            {
                this.referencingEntityNameField = value;
            }
        }

        /// <remarks/>
        public string ReferencedEntityName
        {
            get
            {
                return this.referencedEntityNameField;
            }
            set
            {
                this.referencedEntityNameField = value;
            }
        }

        /// <remarks/>
        public string CascadeAssign
        {
            get
            {
                return this.cascadeAssignField;
            }
            set
            {
                this.cascadeAssignField = value;
            }
        }

        /// <remarks/>
        public string CascadeDelete
        {
            get
            {
                return this.cascadeDeleteField;
            }
            set
            {
                this.cascadeDeleteField = value;
            }
        }

        /// <remarks/>
        public string CascadeReparent
        {
            get
            {
                return this.cascadeReparentField;
            }
            set
            {
                this.cascadeReparentField = value;
            }
        }

        /// <remarks/>
        public string CascadeShare
        {
            get
            {
                return this.cascadeShareField;
            }
            set
            {
                this.cascadeShareField = value;
            }
        }

        /// <remarks/>
        public string CascadeUnshare
        {
            get
            {
                return this.cascadeUnshareField;
            }
            set
            {
                this.cascadeUnshareField = value;
            }
        }

        /// <remarks/>
        public string CascadeRollupView
        {
            get
            {
                return this.cascadeRollupViewField;
            }
            set
            {
                this.cascadeRollupViewField = value;
            }
        }

        /// <remarks/>
        public byte IsValidForAdvancedFind
        {
            get
            {
                return this.isValidForAdvancedFindField;
            }
            set
            {
                this.isValidForAdvancedFindField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsValidForAdvancedFindSpecified
        {
            get
            {
                return this.isValidForAdvancedFindFieldSpecified;
            }
            set
            {
                this.isValidForAdvancedFindFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string ReferencingAttributeName
        {
            get
            {
                return this.referencingAttributeNameField;
            }
            set
            {
                this.referencingAttributeNameField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlEntityRelationshipRelationshipDescription RelationshipDescription
        {
            get
            {
                return this.relationshipDescriptionField;
            }
            set
            {
                this.relationshipDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("EntityRelationshipRole", IsNullable = false)]
        public ImportExportXmlEntityRelationshipEntityRelationshipRole[] EntityRelationshipRoles
        {
            get
            {
                return this.entityRelationshipRolesField;
            }
            set
            {
                this.entityRelationshipRolesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRelationshipRelationshipDescription
    {

        private ImportExportXmlEntityRelationshipRelationshipDescriptionDescriptions descriptionsField;

        /// <remarks/>
        public ImportExportXmlEntityRelationshipRelationshipDescriptionDescriptions Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRelationshipRelationshipDescriptionDescriptions
    {

        private ImportExportXmlEntityRelationshipRelationshipDescriptionDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlEntityRelationshipRelationshipDescriptionDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRelationshipRelationshipDescriptionDescriptionsDescription
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlEntityRelationshipEntityRelationshipRole
    {

        private string navPaneDisplayOptionField;

        private string navPaneAreaField;

        private ushort navPaneOrderField;

        private bool navPaneOrderFieldSpecified;

        private string navigationPropertyNameField;

        private byte relationshipRoleTypeField;

        /// <remarks/>
        public string NavPaneDisplayOption
        {
            get
            {
                return this.navPaneDisplayOptionField;
            }
            set
            {
                this.navPaneDisplayOptionField = value;
            }
        }

        /// <remarks/>
        public string NavPaneArea
        {
            get
            {
                return this.navPaneAreaField;
            }
            set
            {
                this.navPaneAreaField = value;
            }
        }

        /// <remarks/>
        public ushort NavPaneOrder
        {
            get
            {
                return this.navPaneOrderField;
            }
            set
            {
                this.navPaneOrderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NavPaneOrderSpecified
        {
            get
            {
                return this.navPaneOrderFieldSpecified;
            }
            set
            {
                this.navPaneOrderFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string NavigationPropertyName
        {
            get
            {
                return this.navigationPropertyNameField;
            }
            set
            {
                this.navigationPropertyNameField = value;
            }
        }

        /// <remarks/>
        public byte RelationshipRoleType
        {
            get
            {
                return this.relationshipRoleTypeField;
            }
            set
            {
                this.relationshipRoleTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionset
    {

        private string optionSetTypeField;

        private byte isGlobalField;

        private string introducedVersionField;

        private ImportExportXmlOptionsetDisplaynames displaynamesField;

        private ImportExportXmlOptionsetDescriptions descriptionsField;

        private ImportExportXmlOptionsetOption[] optionsField;

        private string nameField;

        private string localizedNameField;

        /// <remarks/>
        public string OptionSetType
        {
            get
            {
                return this.optionSetTypeField;
            }
            set
            {
                this.optionSetTypeField = value;
            }
        }

        /// <remarks/>
        public byte IsGlobal
        {
            get
            {
                return this.isGlobalField;
            }
            set
            {
                this.isGlobalField = value;
            }
        }

        /// <remarks/>
        public string IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlOptionsetDisplaynames displaynames
        {
            get
            {
                return this.displaynamesField;
            }
            set
            {
                this.displaynamesField = value;
            }
        }

        /// <remarks/>
        public ImportExportXmlOptionsetDescriptions Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("option", IsNullable = false)]
        public ImportExportXmlOptionsetOption[] options
        {
            get
            {
                return this.optionsField;
            }
            set
            {
                this.optionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string localizedName
        {
            get
            {
                return this.localizedNameField;
            }
            set
            {
                this.localizedNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionsetDisplaynames
    {

        private ImportExportXmlOptionsetDisplaynamesDisplayname displaynameField;

        /// <remarks/>
        public ImportExportXmlOptionsetDisplaynamesDisplayname displayname
        {
            get
            {
                return this.displaynameField;
            }
            set
            {
                this.displaynameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionsetDisplaynamesDisplayname
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionsetDescriptions
    {

        private ImportExportXmlOptionsetDescriptionsDescription descriptionField;

        /// <remarks/>
        public ImportExportXmlOptionsetDescriptionsDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionsetDescriptionsDescription
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionsetOption
    {

        private ImportExportXmlOptionsetOptionLabels labelsField;

        private uint valueField;

        /// <remarks/>
        public ImportExportXmlOptionsetOptionLabels labels
        {
            get
            {
                return this.labelsField;
            }
            set
            {
                this.labelsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionsetOptionLabels
    {

        private ImportExportXmlOptionsetOptionLabelsLabel labelField;

        /// <remarks/>
        public ImportExportXmlOptionsetOptionLabelsLabel label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlOptionsetOptionLabelsLabel
    {

        private string descriptionField;

        private ushort languagecodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort languagecode
        {
            get
            {
                return this.languagecodeField;
            }
            set
            {
                this.languagecodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlCanvasApp
    {

        private string nameField;

        private System.DateTime appVersionField;

        private string statusField;

        private string createdByClientVersionField;

        private string minClientVersionField;

        private string tagsField;

        private byte isCdsUpgradedField;

        private object galleryItemIdField;

        private string backgroundColorField;

        private string displayNameField;

        private object descriptionField;

        private object commitMessageField;

        private object publisherField;

        private string authorizationReferencesField;

        private string connectionReferencesField;

        private string databaseReferencesField;

        private string appComponentsField;

        private string appComponentDependenciesField;

        private byte canvasAppTypeField;

        private byte bypassConsentField;

        private byte adminControlBypassConsentField;

        private bool adminControlBypassConsentFieldSpecified;

        private object embeddedAppField;

        private decimal introducedVersionField;

        private string cdsDependenciesField;

        private byte isCustomizableField;

        private string backgroundImageUriField;

        private string documentUriField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public System.DateTime AppVersion
        {
            get
            {
                return this.appVersionField;
            }
            set
            {
                this.appVersionField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public string CreatedByClientVersion
        {
            get
            {
                return this.createdByClientVersionField;
            }
            set
            {
                this.createdByClientVersionField = value;
            }
        }

        /// <remarks/>
        public string MinClientVersion
        {
            get
            {
                return this.minClientVersionField;
            }
            set
            {
                this.minClientVersionField = value;
            }
        }

        /// <remarks/>
        public string Tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        public byte IsCdsUpgraded
        {
            get
            {
                return this.isCdsUpgradedField;
            }
            set
            {
                this.isCdsUpgradedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object GalleryItemId
        {
            get
            {
                return this.galleryItemIdField;
            }
            set
            {
                this.galleryItemIdField = value;
            }
        }

        /// <remarks/>
        public string BackgroundColor
        {
            get
            {
                return this.backgroundColorField;
            }
            set
            {
                this.backgroundColorField = value;
            }
        }

        /// <remarks/>
        public string DisplayName
        {
            get
            {
                return this.displayNameField;
            }
            set
            {
                this.displayNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object CommitMessage
        {
            get
            {
                return this.commitMessageField;
            }
            set
            {
                this.commitMessageField = value;
            }
        }

        /// <remarks/>
        public object Publisher
        {
            get
            {
                return this.publisherField;
            }
            set
            {
                this.publisherField = value;
            }
        }

        /// <remarks/>
        public string AuthorizationReferences
        {
            get
            {
                return this.authorizationReferencesField;
            }
            set
            {
                this.authorizationReferencesField = value;
            }
        }

        /// <remarks/>
        public string ConnectionReferences
        {
            get
            {
                return this.connectionReferencesField;
            }
            set
            {
                this.connectionReferencesField = value;
            }
        }

        /// <remarks/>
        public string DatabaseReferences
        {
            get
            {
                return this.databaseReferencesField;
            }
            set
            {
                this.databaseReferencesField = value;
            }
        }

        /// <remarks/>
        public string AppComponents
        {
            get
            {
                return this.appComponentsField;
            }
            set
            {
                this.appComponentsField = value;
            }
        }

        /// <remarks/>
        public string AppComponentDependencies
        {
            get
            {
                return this.appComponentDependenciesField;
            }
            set
            {
                this.appComponentDependenciesField = value;
            }
        }

        /// <remarks/>
        public byte CanvasAppType
        {
            get
            {
                return this.canvasAppTypeField;
            }
            set
            {
                this.canvasAppTypeField = value;
            }
        }

        /// <remarks/>
        public byte BypassConsent
        {
            get
            {
                return this.bypassConsentField;
            }
            set
            {
                this.bypassConsentField = value;
            }
        }

        /// <remarks/>
        public byte AdminControlBypassConsent
        {
            get
            {
                return this.adminControlBypassConsentField;
            }
            set
            {
                this.adminControlBypassConsentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdminControlBypassConsentSpecified
        {
            get
            {
                return this.adminControlBypassConsentFieldSpecified;
            }
            set
            {
                this.adminControlBypassConsentFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object EmbeddedApp
        {
            get
            {
                return this.embeddedAppField;
            }
            set
            {
                this.embeddedAppField = value;
            }
        }

        /// <remarks/>
        public decimal IntroducedVersion
        {
            get
            {
                return this.introducedVersionField;
            }
            set
            {
                this.introducedVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CdsDependencies
        {
            get
            {
                return this.cdsDependenciesField;
            }
            set
            {
                this.cdsDependenciesField = value;
            }
        }

        /// <remarks/>
        public byte IsCustomizable
        {
            get
            {
                return this.isCustomizableField;
            }
            set
            {
                this.isCustomizableField = value;
            }
        }

        /// <remarks/>
        public string BackgroundImageUri
        {
            get
            {
                return this.backgroundImageUriField;
            }
            set
            {
                this.backgroundImageUriField = value;
            }
        }

        /// <remarks/>
        public string DocumentUri
        {
            get
            {
                return this.documentUriField;
            }
            set
            {
                this.documentUriField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlConnectionreference
    {

        private string connectionreferencedisplaynameField;

        private string connectoridField;

        private byte iscustomizableField;

        private byte statecodeField;

        private byte statuscodeField;

        private string connectionreferencelogicalnameField;

        /// <remarks/>
        public string connectionreferencedisplayname
        {
            get
            {
                return this.connectionreferencedisplaynameField;
            }
            set
            {
                this.connectionreferencedisplaynameField = value;
            }
        }

        /// <remarks/>
        public string connectorid
        {
            get
            {
                return this.connectoridField;
            }
            set
            {
                this.connectoridField = value;
            }
        }

        /// <remarks/>
        public byte iscustomizable
        {
            get
            {
                return this.iscustomizableField;
            }
            set
            {
                this.iscustomizableField = value;
            }
        }

        /// <remarks/>
        public byte statecode
        {
            get
            {
                return this.statecodeField;
            }
            set
            {
                this.statecodeField = value;
            }
        }

        /// <remarks/>
        public byte statuscode
        {
            get
            {
                return this.statuscodeField;
            }
            set
            {
                this.statuscodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string connectionreferencelogicalname
        {
            get
            {
                return this.connectionreferencelogicalnameField;
            }
            set
            {
                this.connectionreferencelogicalnameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImportExportXmlLanguages
    {

        private ushort languageField;

        /// <remarks/>
        public ushort Language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }
    }
    */


    [XmlRoot(ElementName = "Name")]
	public class Name
	{
		[XmlAttribute(AttributeName = "LocalizedName")]
		public string LocalizedName { get; set; }
		[XmlAttribute(AttributeName = "OriginalName")]
		public string OriginalName { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "LocalizedName")]
	public class LocalizedName
	{
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "languagecode")]
		public string Languagecode { get; set; }
	}

	[XmlRoot(ElementName = "LocalizedNames")]
	public class LocalizedNames
	{
		[XmlElement(ElementName = "LocalizedName")]
		public LocalizedName LocalizedName { get; set; }
	}

	[XmlRoot(ElementName = "LocalizedCollectionName")]
	public class LocalizedCollectionName
	{
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "languagecode")]
		public string Languagecode { get; set; }
	}

	[XmlRoot(ElementName = "LocalizedCollectionNames")]
	public class LocalizedCollectionNames
	{
		[XmlElement(ElementName = "LocalizedCollectionName")]
		public LocalizedCollectionName LocalizedCollectionName { get; set; }
	}

	[XmlRoot(ElementName = "Description")]
	public class Description
	{
		[XmlAttribute(AttributeName = "description")]
		public string LaDescription { get; set; }
		[XmlAttribute(AttributeName = "languagecode")]
		public string Languagecode { get; set; }
		[XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string Nil { get; set; }
	}

	[XmlRoot(ElementName = "Descriptions")]
	public class Descriptions
	{
		[XmlElement(ElementName = "Description")]
		public Description Description { get; set; }
	}

	[XmlRoot(ElementName = "displayname")]
	public class Displayname
	{
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "languagecode")]
		public string Languagecode { get; set; }
	}

	[XmlRoot(ElementName = "displaynames")]
	public class Displaynames
	{
		[XmlElement(ElementName = "displayname")]
		public Displayname Displayname { get; set; }
	}

	[XmlRoot(ElementName = "attribute")]
	public class Attribute
	{
		[XmlElement(ElementName = "Type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string _Name { get; set; }
		[XmlElement(ElementName = "LogicalName")]
		public string LogicalName { get; set; }
		[XmlElement(ElementName = "RequiredLevel")]
		public string RequiredLevel { get; set; }
		[XmlElement(ElementName = "DisplayMask")]
		public string DisplayMask { get; set; }
		[XmlElement(ElementName = "ImeMode")]
		public string ImeMode { get; set; }
		[XmlElement(ElementName = "ValidForUpdateApi")]
		public string ValidForUpdateApi { get; set; }
		[XmlElement(ElementName = "ValidForReadApi")]
		public string ValidForReadApi { get; set; }
		[XmlElement(ElementName = "ValidForCreateApi")]
		public string ValidForCreateApi { get; set; }
		[XmlElement(ElementName = "IsCustomField")]
		public string IsCustomField { get; set; }
		[XmlElement(ElementName = "IsAuditEnabled")]
		public string IsAuditEnabled { get; set; }
		[XmlElement(ElementName = "IsSecured")]
		public string IsSecured { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "IsRenameable")]
		public string IsRenameable { get; set; }
		[XmlElement(ElementName = "CanModifySearchSettings")]
		public string CanModifySearchSettings { get; set; }
		[XmlElement(ElementName = "CanModifyRequirementLevelSettings")]
		public string CanModifyRequirementLevelSettings { get; set; }
		[XmlElement(ElementName = "CanModifyAdditionalSettings")]
		public string CanModifyAdditionalSettings { get; set; }
		[XmlElement(ElementName = "SourceType")]
		public string SourceType { get; set; }
		[XmlElement(ElementName = "IsGlobalFilterEnabled")]
		public string IsGlobalFilterEnabled { get; set; }
		[XmlElement(ElementName = "IsSortableEnabled")]
		public string IsSortableEnabled { get; set; }
		[XmlElement(ElementName = "CanModifyGlobalFilterSettings")]
		public string CanModifyGlobalFilterSettings { get; set; }
		[XmlElement(ElementName = "CanModifyIsSortableSettings")]
		public string CanModifyIsSortableSettings { get; set; }
		[XmlElement(ElementName = "IsDataSourceSecret")]
		public string IsDataSourceSecret { get; set; }
		[XmlElement(ElementName = "AutoNumberFormat")]
		public string AutoNumberFormat { get; set; }
		[XmlElement(ElementName = "IsSearchable")]
		public string IsSearchable { get; set; }
		[XmlElement(ElementName = "IsFilterable")]
		public string IsFilterable { get; set; }
		[XmlElement(ElementName = "IsRetrievable")]
		public string IsRetrievable { get; set; }
		[XmlElement(ElementName = "IsLocalizable")]
		public string IsLocalizable { get; set; }
		[XmlElement(ElementName = "AppDefaultValue")]
		public string AppDefaultValue { get; set; }
		[XmlElement(ElementName = "OptionSetName")]
		public string OptionSetName { get; set; }
		[XmlElement(ElementName = "displaynames")]
		public Displaynames Displaynames { get; set; }
		[XmlElement(ElementName = "Descriptions")]
		public Descriptions Descriptions { get; set; }
		[XmlAttribute(AttributeName = "PhysicalName")]
		public string PhysicalName { get; set; }
		[XmlElement(ElementName = "Format")]
		public string Format { get; set; }
		[XmlElement(ElementName = "MaxLength")]
		public string MaxLength { get; set; }
		[XmlElement(ElementName = "Length")]
		public string Length { get; set; }
		[XmlElement(ElementName = "MinValue")]
		public string MinValue { get; set; }
		[XmlElement(ElementName = "MaxValue")]
		public string MaxValue { get; set; }
		[XmlElement(ElementName = "LookupStyle")]
		public string LookupStyle { get; set; }
		[XmlElement(ElementName = "CanChangeDateTimeBehavior")]
		public string CanChangeDateTimeBehavior { get; set; }
		[XmlElement(ElementName = "Behavior")]
		public string Behavior { get; set; }
		[XmlElement(ElementName = "LookupTypes")]
		public LookupTypes LookupTypes { get; set; }
		[XmlElement(ElementName = "IsLogical")]
		public string IsLogical { get; set; }
		[XmlElement(ElementName = "optionset")]
		public Optionset Optionset { get; set; }
		[XmlElement(ElementName = "FormulaDefinitionFileName")]
		public string FormulaDefinitionFileName { get; set; }
		[XmlElement(ElementName = "ExternalName")]
		public string ExternalName { get; set; }
		[XmlElement(ElementName = "Accuracy")]
		public string Accuracy { get; set; }
	}

	[XmlRoot(ElementName = "LookupType")]
	public class LookupType
	{
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "LookupTypes")]
	public class LookupTypes
	{
		[XmlElement(ElementName = "LookupType")]
		public List<LookupType> LookupType { get; set; }
	}

	[XmlRoot(ElementName = "label")]
	public class Label
	{
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "languagecode")]
		public string Languagecode { get; set; }
	}

	[XmlRoot(ElementName = "labels")]
	public class Labels
	{
		[XmlElement(ElementName = "label")]
		public Label Label { get; set; }
	}

	[XmlRoot(ElementName = "state")]
	public class State
	{
		[XmlElement(ElementName = "labels")]
		public Labels Labels { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "defaultstatus")]
		public string Defaultstatus { get; set; }
		[XmlAttribute(AttributeName = "invariantname")]
		public string Invariantname { get; set; }
	}

	[XmlRoot(ElementName = "states")]
	public class States
	{
		[XmlElement(ElementName = "state")]
		public List<State> State { get; set; }
	}

	[XmlRoot(ElementName = "optionset")]
	public class Optionset
	{
		[XmlElement(ElementName = "OptionSetType")]
		public string OptionSetType { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "displaynames")]
		public Displaynames Displaynames { get; set; }
		[XmlElement(ElementName = "Descriptions")]
		public Descriptions Descriptions { get; set; }
		[XmlElement(ElementName = "states")]
		public States States { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "statuses")]
		public Statuses Statuses { get; set; }
		[XmlElement(ElementName = "options")]
		public Options Options { get; set; }
		[XmlElement(ElementName = "IsGlobal")]
		public string IsGlobal { get; set; }
		[XmlAttribute(AttributeName = "localizedName")]
		public string LocalizedName { get; set; }
	}

	[XmlRoot(ElementName = "status")]
	public class Status
	{
		[XmlElement(ElementName = "labels")]
		public Labels Labels { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "state")]
		public string State { get; set; }
	}

	[XmlRoot(ElementName = "statuses")]
	public class Statuses
	{
		[XmlElement(ElementName = "status")]
		public List<Status> Status { get; set; }
	}

	[XmlRoot(ElementName = "attributes")]
	public class Attributes
	{
		[XmlElement(ElementName = "attribute")]
		public List<Attribute> Attribute { get; set; }
	}

	[XmlRoot(ElementName = "entity")]
	public class Entity
	{
		[XmlElement(ElementName = "LocalizedNames")]
		public LocalizedNames LocalizedNames { get; set; }
		[XmlElement(ElementName = "LocalizedCollectionNames")]
		public LocalizedCollectionNames LocalizedCollectionNames { get; set; }
		[XmlElement(ElementName = "Descriptions")]
		public Descriptions Descriptions { get; set; }
		[XmlElement(ElementName = "attributes")]
		public Attributes Attributes { get; set; }
		[XmlElement(ElementName = "EntitySetName")]
		public string EntitySetName { get; set; }
		[XmlElement(ElementName = "IsDuplicateCheckSupported")]
		public string IsDuplicateCheckSupported { get; set; }
		[XmlElement(ElementName = "IsBusinessProcessEnabled")]
		public string IsBusinessProcessEnabled { get; set; }
		[XmlElement(ElementName = "IsRequiredOffline")]
		public string IsRequiredOffline { get; set; }
		[XmlElement(ElementName = "IsInteractionCentricEnabled")]
		public string IsInteractionCentricEnabled { get; set; }
		[XmlElement(ElementName = "IsCollaboration")]
		public string IsCollaboration { get; set; }
		[XmlElement(ElementName = "AutoRouteToOwnerQueue")]
		public string AutoRouteToOwnerQueue { get; set; }
		[XmlElement(ElementName = "IsConnectionsEnabled")]
		public string IsConnectionsEnabled { get; set; }
		[XmlElement(ElementName = "IsDocumentManagementEnabled")]
		public string IsDocumentManagementEnabled { get; set; }
		[XmlElement(ElementName = "AutoCreateAccessTeams")]
		public string AutoCreateAccessTeams { get; set; }
		[XmlElement(ElementName = "IsOneNoteIntegrationEnabled")]
		public string IsOneNoteIntegrationEnabled { get; set; }
		[XmlElement(ElementName = "IsKnowledgeManagementEnabled")]
		public string IsKnowledgeManagementEnabled { get; set; }
		[XmlElement(ElementName = "IsSLAEnabled")]
		public string IsSLAEnabled { get; set; }
		[XmlElement(ElementName = "IsDocumentRecommendationsEnabled")]
		public string IsDocumentRecommendationsEnabled { get; set; }
		[XmlElement(ElementName = "IsBPFEntity")]
		public string IsBPFEntity { get; set; }
		[XmlElement(ElementName = "OwnershipTypeMask")]
		public string OwnershipTypeMask { get; set; }
		[XmlElement(ElementName = "IsAuditEnabled")]
		public string IsAuditEnabled { get; set; }
		[XmlElement(ElementName = "IsRetrieveAuditEnabled")]
		public string IsRetrieveAuditEnabled { get; set; }
		[XmlElement(ElementName = "IsRetrieveMultipleAuditEnabled")]
		public string IsRetrieveMultipleAuditEnabled { get; set; }
		[XmlElement(ElementName = "IsActivity")]
		public string IsActivity { get; set; }
		[XmlElement(ElementName = "ActivityTypeMask")]
		public string ActivityTypeMask { get; set; }
		[XmlElement(ElementName = "IsActivityParty")]
		public string IsActivityParty { get; set; }
		[XmlElement(ElementName = "IsReplicated")]
		public string IsReplicated { get; set; }
		[XmlElement(ElementName = "IsReplicationUserFiltered")]
		public string IsReplicationUserFiltered { get; set; }
		[XmlElement(ElementName = "IsMailMergeEnabled")]
		public string IsMailMergeEnabled { get; set; }
		[XmlElement(ElementName = "IsVisibleInMobile")]
		public string IsVisibleInMobile { get; set; }
		[XmlElement(ElementName = "IsVisibleInMobileClient")]
		public string IsVisibleInMobileClient { get; set; }
		[XmlElement(ElementName = "IsReadOnlyInMobileClient")]
		public string IsReadOnlyInMobileClient { get; set; }
		[XmlElement(ElementName = "IsOfflineInMobileClient")]
		public string IsOfflineInMobileClient { get; set; }
		[XmlElement(ElementName = "DaysSinceRecordLastModified")]
		public string DaysSinceRecordLastModified { get; set; }
		[XmlElement(ElementName = "MobileOfflineFilters")]
		public string MobileOfflineFilters { get; set; }
		[XmlElement(ElementName = "IsMapiGridEnabled")]
		public string IsMapiGridEnabled { get; set; }
		[XmlElement(ElementName = "IsReadingPaneEnabled")]
		public string IsReadingPaneEnabled { get; set; }
		[XmlElement(ElementName = "IsQuickCreateEnabled")]
		public string IsQuickCreateEnabled { get; set; }
		[XmlElement(ElementName = "SyncToExternalSearchIndex")]
		public string SyncToExternalSearchIndex { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "IsRenameable")]
		public string IsRenameable { get; set; }
		[XmlElement(ElementName = "IsMappable")]
		public string IsMappable { get; set; }
		[XmlElement(ElementName = "CanModifyAuditSettings")]
		public string CanModifyAuditSettings { get; set; }
		[XmlElement(ElementName = "CanModifyMobileVisibility")]
		public string CanModifyMobileVisibility { get; set; }
		[XmlElement(ElementName = "CanModifyMobileClientVisibility")]
		public string CanModifyMobileClientVisibility { get; set; }
		[XmlElement(ElementName = "CanModifyMobileClientReadOnly")]
		public string CanModifyMobileClientReadOnly { get; set; }
		[XmlElement(ElementName = "CanModifyMobileClientOffline")]
		public string CanModifyMobileClientOffline { get; set; }
		[XmlElement(ElementName = "CanModifyConnectionSettings")]
		public string CanModifyConnectionSettings { get; set; }
		[XmlElement(ElementName = "CanModifyDuplicateDetectionSettings")]
		public string CanModifyDuplicateDetectionSettings { get; set; }
		[XmlElement(ElementName = "CanModifyMailMergeSettings")]
		public string CanModifyMailMergeSettings { get; set; }
		[XmlElement(ElementName = "CanModifyQueueSettings")]
		public string CanModifyQueueSettings { get; set; }
		[XmlElement(ElementName = "CanCreateAttributes")]
		public string CanCreateAttributes { get; set; }
		[XmlElement(ElementName = "CanCreateForms")]
		public string CanCreateForms { get; set; }
		[XmlElement(ElementName = "CanCreateCharts")]
		public string CanCreateCharts { get; set; }
		[XmlElement(ElementName = "CanCreateViews")]
		public string CanCreateViews { get; set; }
		[XmlElement(ElementName = "CanModifyAdditionalSettings")]
		public string CanModifyAdditionalSettings { get; set; }
		[XmlElement(ElementName = "CanEnableSyncToExternalSearchIndex")]
		public string CanEnableSyncToExternalSearchIndex { get; set; }
		[XmlElement(ElementName = "EnforceStateTransitions")]
		public string EnforceStateTransitions { get; set; }
		[XmlElement(ElementName = "CanChangeHierarchicalRelationship")]
		public string CanChangeHierarchicalRelationship { get; set; }
		[XmlElement(ElementName = "EntityHelpUrlEnabled")]
		public string EntityHelpUrlEnabled { get; set; }
		[XmlElement(ElementName = "ChangeTrackingEnabled")]
		public string ChangeTrackingEnabled { get; set; }
		[XmlElement(ElementName = "CanChangeTrackingBeEnabled")]
		public string CanChangeTrackingBeEnabled { get; set; }
		[XmlElement(ElementName = "IsEnabledForExternalChannels")]
		public string IsEnabledForExternalChannels { get; set; }
		[XmlElement(ElementName = "IsSolutionAware")]
		public string IsSolutionAware { get; set; }
		[XmlElement(ElementName = "Name")]
		public List<string> Name { get; set; }
		[XmlElement(ElementName = "attribute")]
		public List<Attribute> Attribute { get; set; }
		[XmlElement(ElementName = "order")]
		public List<Order> Order { get; set; }
		[XmlElement(ElementName = "filter")]
		public List<Filter> Filter { get; set; }
		[XmlElement(ElementName = "HasRelatedNotes")]
		public string HasRelatedNotes { get; set; }
		[XmlElement(ElementName = "EntityColor")]
		public string EntityColor { get; set; }
		[XmlElement(ElementName = "IconVectorName")]
		public string IconVectorName { get; set; }
		[XmlElement(ElementName = "EntityHelpUrl")]
		public string EntityHelpUrl { get; set; }
		[XmlElement(ElementName = "link-entity")]
		public Linkentity Linkentity { get; set; }
	}

	[XmlRoot(ElementName = "EntityInfo")]
	public class EntityInfo
	{
		[XmlElement(ElementName = "entity")]
		public Entity Entity { get; set; }
	}

	[XmlRoot(ElementName = "section")]
	public class Section
	{
		[XmlElement(ElementName = "labels")]
		public Labels Labels { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "showlabel")]
		public string Showlabel { get; set; }
		[XmlAttribute(AttributeName = "showbar")]
		public string Showbar { get; set; }
		[XmlAttribute(AttributeName = "columns")]
		public string Columns { get; set; }
		[XmlAttribute(AttributeName = "IsUserDefined")]
		public string IsUserDefined { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "rows")]
		public Rows Rows { get; set; }
		[XmlAttribute(AttributeName = "height")]
		public string Height { get; set; }
		[XmlAttribute(AttributeName = "labelid")]
		public string Labelid { get; set; }
		[XmlAttribute(AttributeName = "locklevel")]
		public string Locklevel { get; set; }
		[XmlAttribute(AttributeName = "layout")]
		public string Layout { get; set; }
		[XmlAttribute(AttributeName = "celllabelalignment")]
		public string Celllabelalignment { get; set; }
		[XmlAttribute(AttributeName = "celllabelposition")]
		public string Celllabelposition { get; set; }
		[XmlAttribute(AttributeName = "labelwidth")]
		public string Labelwidth { get; set; }
		[XmlAttribute(AttributeName = "visible")]
		public string Visible { get; set; }
	}

	[XmlRoot(ElementName = "sections")]
	public class Sections
	{
		[XmlElement(ElementName = "section")]
		public List<Section> Section { get; set; }
	}

	[XmlRoot(ElementName = "column")]
	public class Column
	{
		[XmlElement(ElementName = "sections")]
		public Sections Sections { get; set; }
		[XmlAttribute(AttributeName = "width")]
		public string Width { get; set; }
	}

	[XmlRoot(ElementName = "control")]
	public class Control
	{
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "classid")]
		public string Classid { get; set; }
		[XmlAttribute(AttributeName = "datafieldname")]
		public string Datafieldname { get; set; }
		[XmlAttribute(AttributeName = "disabled")]
		public string Disabled { get; set; }
		[XmlElement(ElementName = "parameters")]
		public Parameters Parameters { get; set; }
		[XmlAttribute(AttributeName = "indicationOfSubgrid")]
		public string IndicationOfSubgrid { get; set; }
		[XmlAttribute(AttributeName = "uniqueid")]
		public string Uniqueid { get; set; }
	}

	[XmlRoot(ElementName = "cell")]
	public class Cell
	{
		[XmlElement(ElementName = "labels")]
		public Labels Labels { get; set; }
		[XmlElement(ElementName = "control")]
		public Control Control { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "showlabel")]
		public string Showlabel { get; set; }
		[XmlAttribute(AttributeName = "locklevel")]
		public string Locklevel { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "width")]
		public string Width { get; set; }
		[XmlAttribute(AttributeName = "rowspan")]
		public string Rowspan { get; set; }
		[XmlAttribute(AttributeName = "auto")]
		public string Auto { get; set; }
		[XmlAttribute(AttributeName = "labelid")]
		public string Labelid { get; set; }
		[XmlAttribute(AttributeName = "colspan")]
		public string Colspan { get; set; }
	}

	[XmlRoot(ElementName = "row")]
	public class Row
	{
		[XmlElement(ElementName = "cell")]
		public List<Cell> Cell { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "height")]
		public string Height { get; set; }
	}

	[XmlRoot(ElementName = "rows")]
	public class Rows
	{
		[XmlElement(ElementName = "row")]
		public List<Row> Row { get; set; }
	}

	[XmlRoot(ElementName = "columns")]
	public class Columns
	{
		[XmlElement(ElementName = "column")]
		public List<Column> Column { get; set; }
	}

	[XmlRoot(ElementName = "tab")]
	public class Tab
	{
		[XmlElement(ElementName = "labels")]
		public Labels Labels { get; set; }
		[XmlElement(ElementName = "columns")]
		public Columns Columns { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "verticallayout")]
		public string Verticallayout { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "IsUserDefined")]
		public string IsUserDefined { get; set; }
		[XmlAttribute(AttributeName = "labelid")]
		public string Labelid { get; set; }
		[XmlAttribute(AttributeName = "locklevel")]
		public string Locklevel { get; set; }
		[XmlAttribute(AttributeName = "showlabel")]
		public string Showlabel { get; set; }
	}

	[XmlRoot(ElementName = "tabs")]
	public class Tabs
	{
		[XmlElement(ElementName = "tab")]
		public List<Tab> Tab { get; set; }
	}

	[XmlRoot(ElementName = "form")]
	public class Form
	{
		[XmlElement(ElementName = "tabs")]
		public Tabs Tabs { get; set; }
		[XmlElement(ElementName = "header")]
		public Header Header { get; set; }
		[XmlElement(ElementName = "footer")]
		public Footer Footer { get; set; }
		[XmlElement(ElementName = "DisplayConditions")]
		public DisplayConditions DisplayConditions { get; set; }
		[XmlAttribute(AttributeName = "headerdensity")]
		public string Headerdensity { get; set; }
		[XmlElement(ElementName = "formLibraries")]
		public FormLibraries FormLibraries { get; set; }
		[XmlElement(ElementName = "events")]
		public Events Events { get; set; }
		[XmlElement(ElementName = "Navigation")]
		public Navigation Navigation { get; set; }
	}

	[XmlRoot(ElementName = "systemform")]
	public class Systemform
	{
		[XmlElement(ElementName = "formid")]
		public string Formid { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "FormPresentation")]
		public string FormPresentation { get; set; }
		[XmlElement(ElementName = "FormActivationState")]
		public string FormActivationState { get; set; }
		[XmlElement(ElementName = "form")]
		public Form Form { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "CanBeDeleted")]
		public string CanBeDeleted { get; set; }
		[XmlElement(ElementName = "LocalizedNames")]
		public LocalizedNames LocalizedNames { get; set; }
		[XmlElement(ElementName = "Descriptions")]
		public Descriptions Descriptions { get; set; }
	}

	[XmlRoot(ElementName = "forms")]
	public class Forms
	{
		[XmlElement(ElementName = "systemform")]
		public List<Systemform> Systemform { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "header")]
	public class Header
	{
		[XmlElement(ElementName = "rows")]
		public Rows Rows { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "celllabelposition")]
		public string Celllabelposition { get; set; }
		[XmlAttribute(AttributeName = "columns")]
		public string Columns { get; set; }
		[XmlAttribute(AttributeName = "labelwidth")]
		public string Labelwidth { get; set; }
		[XmlAttribute(AttributeName = "celllabelalignment")]
		public string Celllabelalignment { get; set; }
	}

	[XmlRoot(ElementName = "footer")]
	public class Footer
	{
		[XmlElement(ElementName = "rows")]
		public Rows Rows { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "celllabelposition")]
		public string Celllabelposition { get; set; }
		[XmlAttribute(AttributeName = "columns")]
		public string Columns { get; set; }
		[XmlAttribute(AttributeName = "labelwidth")]
		public string Labelwidth { get; set; }
		[XmlAttribute(AttributeName = "celllabelalignment")]
		public string Celllabelalignment { get; set; }
	}

	[XmlRoot(ElementName = "DisplayConditions")]
	public class DisplayConditions
	{
		[XmlElement(ElementName = "Everyone")]
		public string Everyone { get; set; }
		[XmlAttribute(AttributeName = "Order")]
		public string Order { get; set; }
		[XmlAttribute(AttributeName = "FallbackForm")]
		public string FallbackForm { get; set; }
		[XmlElement(ElementName = "Role")]
		public List<Role> Role { get; set; }
	}

	[XmlRoot(ElementName = "FormXml")]
	public class FormXml
	{
		[XmlElement(ElementName = "forms")]
		public List<Forms> Forms { get; set; }
	}

	[XmlRoot(ElementName = "grid")]
	public class Grid
	{
		[XmlElement(ElementName = "row")]
		public Row Row { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "jump")]
		public string Jump { get; set; }
		[XmlAttribute(AttributeName = "select")]
		public string Select { get; set; }
		[XmlAttribute(AttributeName = "icon")]
		public string Icon { get; set; }
		[XmlAttribute(AttributeName = "preview")]
		public string Preview { get; set; }
	}

	[XmlRoot(ElementName = "layoutxml")]
	public class Layoutxml
	{
		[XmlElement(ElementName = "grid")]
		public Grid Grid { get; set; }
	}

	[XmlRoot(ElementName = "order")]
	public class Order
	{
		[XmlAttribute(AttributeName = "attribute")]
		public string Attribute { get; set; }
		[XmlAttribute(AttributeName = "descending")]
		public string Descending { get; set; }
	}

	[XmlRoot(ElementName = "condition")]
	public class Condition
	{
		[XmlAttribute(AttributeName = "attribute")]
		public string Attribute { get; set; }
		[XmlAttribute(AttributeName = "operator")]
		public string Operator { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "filter")]
	public class Filter
	{
		[XmlElement(ElementName = "condition")]
		public List<Condition> Condition { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "isquickfindfields")]
		public string Isquickfindfields { get; set; }
	}

	[XmlRoot(ElementName = "fetch")]
	public class Fetch
	{
		[XmlElement(ElementName = "entity")]
		public Entity Entity { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "mapping")]
		public string Mapping { get; set; }
		[XmlAttribute(AttributeName = "output-format")]
		public string Outputformat { get; set; }
		[XmlAttribute(AttributeName = "distinct")]
		public string Distinct { get; set; }
	}

	[XmlRoot(ElementName = "fetchxml")]
	public class Fetchxml
	{
		[XmlElement(ElementName = "fetch")]
		public Fetch Fetch { get; set; }
	}

	[XmlRoot(ElementName = "savedquery")]
	public class Savedquery
	{
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "CanBeDeleted")]
		public string CanBeDeleted { get; set; }
		[XmlElement(ElementName = "isquickfindquery")]
		public string Isquickfindquery { get; set; }
		[XmlElement(ElementName = "isprivate")]
		public string Isprivate { get; set; }
		[XmlElement(ElementName = "isdefault")]
		public string Isdefault { get; set; }
		[XmlElement(ElementName = "savedqueryid")]
		public string Savedqueryid { get; set; }
		[XmlElement(ElementName = "layoutxml")]
		public Layoutxml Layoutxml { get; set; }
		[XmlElement(ElementName = "querytype")]
		public string Querytype { get; set; }
		[XmlElement(ElementName = "fetchxml")]
		public Fetchxml Fetchxml { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "LocalizedNames")]
		public LocalizedNames LocalizedNames { get; set; }
		[XmlElement(ElementName = "Descriptions")]
		public Descriptions Descriptions { get; set; }
	}

	[XmlRoot(ElementName = "savedqueries")]
	public class Savedqueries
	{
		[XmlElement(ElementName = "savedquery")]
		public List<Savedquery> Savedquery { get; set; }
	}

	[XmlRoot(ElementName = "SavedQueries")]
	public class SavedQueries
	{
		[XmlElement(ElementName = "savedqueries")]
		public Savedqueries Savedqueries { get; set; }
	}

	[XmlRoot(ElementName = "RibbonTemplates")]
	public class RibbonTemplates
	{
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Templates")]
	public class Templates
	{
		[XmlElement(ElementName = "RibbonTemplates")]
		public RibbonTemplates RibbonTemplates { get; set; }
	}

	[XmlRoot(ElementName = "RuleDefinitions")]
	public class RuleDefinitions
	{
		[XmlElement(ElementName = "TabDisplayRules")]
		public string TabDisplayRules { get; set; }
		[XmlElement(ElementName = "DisplayRules")]
		public string DisplayRules { get; set; }
		[XmlElement(ElementName = "EnableRules")]
		public string EnableRules { get; set; }
	}

	[XmlRoot(ElementName = "RibbonDiffXml")]
	public class RibbonDiffXml
	{
		[XmlElement(ElementName = "Templates")]
		public Templates Templates { get; set; }
		[XmlElement(ElementName = "RuleDefinitions")]
		public RuleDefinitions RuleDefinitions { get; set; }
		[XmlElement(ElementName = "LocLabels")]
		public string LocLabels { get; set; }
		[XmlElement(ElementName = "CustomActions")]
		public CustomActions CustomActions { get; set; }
		[XmlElement(ElementName = "CommandDefinitions")]
		public CommandDefinitions CommandDefinitions { get; set; }
	}

	[XmlRoot(ElementName = "Entity")]
	public class Entity2
	{
		[XmlElement(ElementName = "Name")]
		public Name Name { get; set; }
		[XmlElement(ElementName = "EntityInfo")]
		public EntityInfo EntityInfo { get; set; }
		[XmlElement(ElementName = "FormXml")]
		public FormXml FormXml { get; set; }
		[XmlElement(ElementName = "SavedQueries")]
		public SavedQueries SavedQueries { get; set; }
		[XmlElement(ElementName = "RibbonDiffXml")]
		public RibbonDiffXml RibbonDiffXml { get; set; }
		[XmlElement(ElementName = "CustomControlDefaultConfigs")]
		public CustomControlDefaultConfigs CustomControlDefaultConfigs { get; set; }
	}

	[XmlRoot(ElementName = "Library")]
	public class Library
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "libraryUniqueId")]
		public string LibraryUniqueId { get; set; }
	}

	[XmlRoot(ElementName = "formLibraries")]
	public class FormLibraries
	{
		[XmlElement(ElementName = "Library")]
		public Library Library { get; set; }
	}

	[XmlRoot(ElementName = "Handler")]
	public class Handler
	{
		[XmlAttribute(AttributeName = "functionName")]
		public string FunctionName { get; set; }
		[XmlAttribute(AttributeName = "libraryName")]
		public string LibraryName { get; set; }
		[XmlAttribute(AttributeName = "handlerUniqueId")]
		public string HandlerUniqueId { get; set; }
		[XmlAttribute(AttributeName = "enabled")]
		public string Enabled { get; set; }
		[XmlAttribute(AttributeName = "parameters")]
		public string Parameters { get; set; }
		[XmlAttribute(AttributeName = "passExecutionContext")]
		public string PassExecutionContext { get; set; }
	}

	[XmlRoot(ElementName = "Handlers")]
	public class Handlers
	{
		[XmlElement(ElementName = "Handler")]
		public Handler Handler { get; set; }
	}

	[XmlRoot(ElementName = "event")]
	public class Event
	{
		[XmlElement(ElementName = "Handlers")]
		public Handlers Handlers { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "application")]
		public string Application { get; set; }
		[XmlAttribute(AttributeName = "active")]
		public string Active { get; set; }
		[XmlAttribute(AttributeName = "relationship")]
		public string Relationship { get; set; }
		[XmlAttribute(AttributeName = "control")]
		public string Control { get; set; }
	}

	[XmlRoot(ElementName = "events")]
	public class Events
	{
		[XmlElement(ElementName = "event")]
		public Event Event { get; set; }
	}

	[XmlRoot(ElementName = "parameters")]
	public class Parameters
	{
		[XmlElement(ElementName = "DefaultTabId")]
		public string DefaultTabId { get; set; }
		[XmlElement(ElementName = "TargetEntityType")]
		public string TargetEntityType { get; set; }
		[XmlElement(ElementName = "ViewId")]
		public string ViewId { get; set; }
		[XmlElement(ElementName = "ViewIds")]
		public string ViewIds { get; set; }
		[XmlElement(ElementName = "EnableViewPicker")]
		public string EnableViewPicker { get; set; }
		[XmlElement(ElementName = "RelationshipName")]
		public string RelationshipName { get; set; }
		[XmlElement(ElementName = "AutoExpand")]
		public string AutoExpand { get; set; }
		[XmlElement(ElementName = "UClientUniqueName")]
		public string UClientUniqueName { get; set; }
		[XmlElement(ElementName = "UClientModules")]
		public string UClientModules { get; set; }
		[XmlElement(ElementName = "UClientDefaultModuleForCreateExperience")]
		public string UClientDefaultModuleForCreateExperience { get; set; }
		[XmlElement(ElementName = "UClientShowFilterPane")]
		public string UClientShowFilterPane { get; set; }
		[XmlElement(ElementName = "UClientExpandFilterPane")]
		public string UClientExpandFilterPane { get; set; }
		[XmlElement(ElementName = "UClientOrderBy")]
		public string UClientOrderBy { get; set; }
		[XmlElement(ElementName = "UClientRecordPerPage")]
		public string UClientRecordPerPage { get; set; }
		[XmlElement(ElementName = "UClientEnableWhatsNewFilter")]
		public string UClientEnableWhatsNewFilter { get; set; }
		[XmlElement(ElementName = "EmailConversationView")]
		public string EmailConversationView { get; set; }
		[XmlElement(ElementName = "ShowArticleTab")]
		public string ShowArticleTab { get; set; }
		[XmlElement(ElementName = "SelectDefaultLanguage")]
		public string SelectDefaultLanguage { get; set; }
		[XmlElement(ElementName = "data-set")]
		public Dataset Dataset { get; set; }
		[XmlElement(ElementName = "EnableGroupBy")]
		public EnableGroupBy EnableGroupBy { get; set; }
		[XmlElement(ElementName = "EnableEditing")]
		public EnableEditing EnableEditing { get; set; }
		[XmlElement(ElementName = "ReflowBehavior")]
		public ReflowBehavior ReflowBehavior { get; set; }
		[XmlElement(ElementName = "ListLayoutDirection")]
		public ListLayoutDirection ListLayoutDirection { get; set; }
		[XmlElement(ElementName = "EnableSubGridAutoCollapse")]
		public EnableSubGridAutoCollapse EnableSubGridAutoCollapse { get; set; }
		[XmlElement(ElementName = "EnableFiltering")]
		public EnableFiltering EnableFiltering { get; set; }
		[XmlElement(ElementName = "HideNestedGridColumnHeader")]
		public HideNestedGridColumnHeader HideNestedGridColumnHeader { get; set; }
		[XmlElement(ElementName = "EnableJumpBar")]
		public EnableJumpBar EnableJumpBar { get; set; }
	}

	[XmlRoot(ElementName = "Role")]
	public class Role
	{
		[XmlElement(ElementName = "Id")]
		public List<string> Id { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "RolePrivileges")]
		public RolePrivileges RolePrivileges { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "isinherited")]
		public string Isinherited { get; set; }
	}

	[XmlRoot(ElementName = "option")]
	public class Option
	{
		[XmlElement(ElementName = "labels")]
		public Labels Labels { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "options")]
	public class Options
	{
		[XmlElement(ElementName = "option")]
		public List<Option> Option { get; set; }
	}

	[XmlRoot(ElementName = "Title")]
	public class Title
	{
		[XmlAttribute(AttributeName = "LCID")]
		public string LCID { get; set; }
		[XmlAttribute(AttributeName = "Text")]
		public string Text { get; set; }
		[XmlAttribute(AttributeName = "Title")]
		public string _Title { get; set; }
	}

	[XmlRoot(ElementName = "Titles")]
	public class Titles
	{
		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }
	}

	[XmlRoot(ElementName = "NavBarArea")]
	public class NavBarArea
	{
		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "NavBarAreas")]
	public class NavBarAreas
	{
		[XmlElement(ElementName = "NavBarArea")]
		public List<NavBarArea> NavBarArea { get; set; }
	}

	[XmlRoot(ElementName = "Navigation")]
	public class Navigation
	{
		[XmlElement(ElementName = "NavBar")]
		public string NavBar { get; set; }
		[XmlElement(ElementName = "NavBarAreas")]
		public NavBarAreas NavBarAreas { get; set; }
	}

	[XmlRoot(ElementName = "link-entity")]
	public class Linkentity
	{
		[XmlElement(ElementName = "filter")]
		public Filter Filter { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "from")]
		public string From { get; set; }
		[XmlAttribute(AttributeName = "to")]
		public string To { get; set; }
		[XmlAttribute(AttributeName = "alias")]
		public string Alias { get; set; }
		[XmlElement(ElementName = "attribute")]
		public List<Attribute> Attribute { get; set; }
		[XmlAttribute(AttributeName = "link-type")]
		public string Linktype { get; set; }
		[XmlAttribute(AttributeName = "visible")]
		public string Visible { get; set; }
	}

	[XmlRoot(ElementName = "HideCustomAction")]
	public class HideCustomAction
	{
		[XmlAttribute(AttributeName = "HideActionId")]
		public string HideActionId { get; set; }
		[XmlAttribute(AttributeName = "Location")]
		public string Location { get; set; }
	}

	[XmlRoot(ElementName = "CustomActions")]
	public class CustomActions
	{
		[XmlElement(ElementName = "HideCustomAction")]
		public List<HideCustomAction> HideCustomAction { get; set; }
	}

	[XmlRoot(ElementName = "CrmParameter")]
	public class CrmParameter
	{
		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "JavaScriptFunction")]
	public class JavaScriptFunction
	{
		[XmlElement(ElementName = "CrmParameter")]
		public CrmParameter CrmParameter { get; set; }
		[XmlAttribute(AttributeName = "FunctionName")]
		public string FunctionName { get; set; }
		[XmlAttribute(AttributeName = "Library")]
		public string Library { get; set; }
	}

	[XmlRoot(ElementName = "Actions")]
	public class Actions
	{
		[XmlElement(ElementName = "JavaScriptFunction")]
		public JavaScriptFunction JavaScriptFunction { get; set; }
	}

	[XmlRoot(ElementName = "CommandDefinition")]
	public class CommandDefinition
	{
		[XmlElement(ElementName = "EnableRules")]
		public string EnableRules { get; set; }
		[XmlElement(ElementName = "DisplayRules")]
		public string DisplayRules { get; set; }
		[XmlElement(ElementName = "Actions")]
		public Actions Actions { get; set; }
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "CommandDefinitions")]
	public class CommandDefinitions
	{
		[XmlElement(ElementName = "CommandDefinition")]
		public CommandDefinition CommandDefinition { get; set; }
	}

	[XmlRoot(ElementName = "customControl")]
	public class CustomControl
	{
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "formFactor")]
		public string FormFactor { get; set; }
		[XmlElement(ElementName = "parameters")]
		public Parameters Parameters { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "data-set")]
	public class Dataset
	{
		[XmlElement(ElementName = "columnsDefaultView")]
		public string ColumnsDefaultView { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "EnableGroupBy")]
	public class EnableGroupBy
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "EnableEditing")]
	public class EnableEditing
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "ReflowBehavior")]
	public class ReflowBehavior
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "ListLayoutDirection")]
	public class ListLayoutDirection
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "EnableSubGridAutoCollapse")]
	public class EnableSubGridAutoCollapse
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "EnableFiltering")]
	public class EnableFiltering
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "HideNestedGridColumnHeader")]
	public class HideNestedGridColumnHeader
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "EnableJumpBar")]
	public class EnableJumpBar
	{
		[XmlAttribute(AttributeName = "static")]
		public string Static { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "controlDescription")]
	public class ControlDescription
	{
		[XmlElement(ElementName = "customControl")]
		public List<CustomControl> CustomControl { get; set; }
	}

	[XmlRoot(ElementName = "controlDescriptions")]
	public class ControlDescriptions
	{
		[XmlElement(ElementName = "controlDescription")]
		public ControlDescription ControlDescription { get; set; }
	}

	[XmlRoot(ElementName = "ControlDescriptionXML")]
	public class ControlDescriptionXML
	{
		[XmlElement(ElementName = "controlDescriptions")]
		public ControlDescriptions ControlDescriptions { get; set; }
	}

	[XmlRoot(ElementName = "CustomControlDefaultConfig")]
	public class CustomControlDefaultConfig
	{
		[XmlElement(ElementName = "ControlDescriptionXML")]
		public ControlDescriptionXML ControlDescriptionXML { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "formLibraries")]
		public FormLibraries FormLibraries { get; set; }
		[XmlElement(ElementName = "events")]
		public Events Events { get; set; }
	}

	[XmlRoot(ElementName = "CustomControlDefaultConfigs")]
	public class CustomControlDefaultConfigs
	{
		[XmlElement(ElementName = "CustomControlDefaultConfig")]
		public CustomControlDefaultConfig CustomControlDefaultConfig { get; set; }
	}

	[XmlRoot(ElementName = "Entities")]
	public class Entities
	{
		[XmlElement(ElementName = "Entity")]
		public List<Entity> Entity { get; set; }
	}

	[XmlRoot(ElementName = "RolePrivilege")]
	public class RolePrivilege
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "level")]
		public string Level { get; set; }
	}

	[XmlRoot(ElementName = "RolePrivileges")]
	public class RolePrivileges
	{
		[XmlElement(ElementName = "RolePrivilege")]
		public List<RolePrivilege> RolePrivilege { get; set; }
	}

	[XmlRoot(ElementName = "Roles")]
	public class Roles
	{
		[XmlElement(ElementName = "Role")]
		public Role Role { get; set; }
	}

	[XmlRoot(ElementName = "Workflow")]
	public class Workflow
	{
		[XmlElement(ElementName = "JsonFileName")]
		public string JsonFileName { get; set; }
		[XmlElement(ElementName = "Type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "Subprocess")]
		public string Subprocess { get; set; }
		[XmlElement(ElementName = "Category")]
		public string Category { get; set; }
		[XmlElement(ElementName = "Mode")]
		public string Mode { get; set; }
		[XmlElement(ElementName = "Scope")]
		public string Scope { get; set; }
		[XmlElement(ElementName = "OnDemand")]
		public string OnDemand { get; set; }
		[XmlElement(ElementName = "TriggerOnCreate")]
		public string TriggerOnCreate { get; set; }
		[XmlElement(ElementName = "TriggerOnDelete")]
		public string TriggerOnDelete { get; set; }
		[XmlElement(ElementName = "AsyncAutodelete")]
		public string AsyncAutodelete { get; set; }
		[XmlElement(ElementName = "SyncWorkflowLogOnFailure")]
		public string SyncWorkflowLogOnFailure { get; set; }
		[XmlElement(ElementName = "StateCode")]
		public string StateCode { get; set; }
		[XmlElement(ElementName = "StatusCode")]
		public string StatusCode { get; set; }
		[XmlElement(ElementName = "RunAs")]
		public string RunAs { get; set; }
		[XmlElement(ElementName = "IsTransacted")]
		public string IsTransacted { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "BusinessProcessType")]
		public string BusinessProcessType { get; set; }
		[XmlElement(ElementName = "IsCustomProcessingStepAllowedForOtherPublishers")]
		public string IsCustomProcessingStepAllowedForOtherPublishers { get; set; }
		[XmlElement(ElementName = "PrimaryEntity")]
		public string PrimaryEntity { get; set; }
		[XmlElement(ElementName = "LocalizedNames")]
		public LocalizedNames LocalizedNames { get; set; }
		[XmlAttribute(AttributeName = "WorkflowId")]
		public string WorkflowId { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "Workflows")]
	public class Workflows
	{
		[XmlElement(ElementName = "Workflow")]
		public List<Workflow> Workflow { get; set; }
	}

	[XmlRoot(ElementName = "RelationshipDescription")]
	public class RelationshipDescription
	{
		[XmlElement(ElementName = "Descriptions")]
		public Descriptions Descriptions { get; set; }
	}

	[XmlRoot(ElementName = "EntityRelationship")]
	public class EntityRelationship
	{
		[XmlElement(ElementName = "EntityRelationshipType")]
		public string EntityRelationshipType { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "IsHierarchical")]
		public string IsHierarchical { get; set; }
		[XmlElement(ElementName = "ReferencingEntityName")]
		public string ReferencingEntityName { get; set; }
		[XmlElement(ElementName = "ReferencedEntityName")]
		public string ReferencedEntityName { get; set; }
		[XmlElement(ElementName = "CascadeAssign")]
		public string CascadeAssign { get; set; }
		[XmlElement(ElementName = "CascadeDelete")]
		public string CascadeDelete { get; set; }
		[XmlElement(ElementName = "CascadeReparent")]
		public string CascadeReparent { get; set; }
		[XmlElement(ElementName = "CascadeShare")]
		public string CascadeShare { get; set; }
		[XmlElement(ElementName = "CascadeUnshare")]
		public string CascadeUnshare { get; set; }
		[XmlElement(ElementName = "ReferencingAttributeName")]
		public string ReferencingAttributeName { get; set; }
		[XmlElement(ElementName = "RelationshipDescription")]
		public RelationshipDescription RelationshipDescription { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "CascadeRollupView")]
		public string CascadeRollupView { get; set; }
		[XmlElement(ElementName = "IsValidForAdvancedFind")]
		public string IsValidForAdvancedFind { get; set; }
		[XmlElement(ElementName = "EntityRelationshipRoles")]
		public EntityRelationshipRoles EntityRelationshipRoles { get; set; }
		[XmlElement(ElementName = "FirstEntityName")]
		public string FirstEntityName { get; set; }
		[XmlElement(ElementName = "SecondEntityName")]
		public string SecondEntityName { get; set; }
		[XmlElement(ElementName = "IntersectEntityName")]
		public string IntersectEntityName { get; set; }
	}

	[XmlRoot(ElementName = "EntityRelationshipRole")]
	public class EntityRelationshipRole
	{
		[XmlElement(ElementName = "NavPaneDisplayOption")]
		public string NavPaneDisplayOption { get; set; }
		[XmlElement(ElementName = "NavPaneArea")]
		public string NavPaneArea { get; set; }
		[XmlElement(ElementName = "NavPaneOrder")]
		public string NavPaneOrder { get; set; }
		[XmlElement(ElementName = "NavigationPropertyName")]
		public string NavigationPropertyName { get; set; }
		[XmlElement(ElementName = "RelationshipRoleType")]
		public string RelationshipRoleType { get; set; }
		[XmlElement(ElementName = "AssociationRoleOrdinal")]
		public string AssociationRoleOrdinal { get; set; }
	}

	[XmlRoot(ElementName = "EntityRelationshipRoles")]
	public class EntityRelationshipRoles
	{
		[XmlElement(ElementName = "EntityRelationshipRole")]
		public List<EntityRelationshipRole> EntityRelationshipRole { get; set; }
	}

	[XmlRoot(ElementName = "EntityRelationships")]
	public class EntityRelationships
	{
		[XmlElement(ElementName = "EntityRelationship")]
		public List<EntityRelationship> EntityRelationship { get; set; }
	}

	[XmlRoot(ElementName = "optionsets")]
	public class Optionsets
	{
		[XmlElement(ElementName = "optionset")]
		public List<Optionset> Optionset { get; set; }
	}

	[XmlRoot(ElementName = "WebResource")]
	public class WebResource
	{
		[XmlElement(ElementName = "WebResourceId")]
		public string WebResourceId { get; set; }
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "DisplayName")]
		public string DisplayName { get; set; }
		[XmlElement(ElementName = "LanguageCode")]
		public string LanguageCode { get; set; }
		[XmlElement(ElementName = "WebResourceType")]
		public string WebResourceType { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "IsEnabledForMobileClient")]
		public string IsEnabledForMobileClient { get; set; }
		[XmlElement(ElementName = "IsAvailableForMobileOffline")]
		public string IsAvailableForMobileOffline { get; set; }
		[XmlElement(ElementName = "DependencyXml")]
		public string DependencyXml { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "CanBeDeleted")]
		public string CanBeDeleted { get; set; }
		[XmlElement(ElementName = "IsHidden")]
		public string IsHidden { get; set; }
		[XmlElement(ElementName = "FileName")]
		public string FileName { get; set; }
	}

	[XmlRoot(ElementName = "WebResources")]
	public class WebResources
	{
		[XmlElement(ElementName = "WebResource")]
		public List<WebResource> WebResource { get; set; }
	}

	[XmlRoot(ElementName = "CustomControl")]
	public class CustomControl2
	{
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "FileName")]
		public string FileName { get; set; }
	}

	[XmlRoot(ElementName = "CustomControls")]
	public class CustomControls
	{
		[XmlElement(ElementName = "CustomControl")]
		public List<CustomControl> CustomControl { get; set; }
	}

	[XmlRoot(ElementName = "PluginType")]
	public class PluginType
	{
		[XmlElement(ElementName = "FriendlyName")]
		public string FriendlyName { get; set; }
		[XmlAttribute(AttributeName = "AssemblyQualifiedName")]
		public string AssemblyQualifiedName { get; set; }
		[XmlAttribute(AttributeName = "PluginTypeId")]
		public string PluginTypeId { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "PluginTypes")]
	public class PluginTypes
	{
		[XmlElement(ElementName = "PluginType")]
		public List<PluginType> PluginType { get; set; }
	}

	[XmlRoot(ElementName = "PluginAssembly")]
	public class PluginAssembly
	{
		[XmlElement(ElementName = "IsolationMode")]
		public string IsolationMode { get; set; }
		[XmlElement(ElementName = "SourceType")]
		public string SourceType { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "FileName")]
		public string FileName { get; set; }
		[XmlElement(ElementName = "PluginTypes")]
		public PluginTypes PluginTypes { get; set; }
		[XmlAttribute(AttributeName = "FullName")]
		public string FullName { get; set; }
		[XmlAttribute(AttributeName = "PluginAssemblyId")]
		public string PluginAssemblyId { get; set; }
		[XmlAttribute(AttributeName = "CustomizationLevel")]
		public string CustomizationLevel { get; set; }
	}

	[XmlRoot(ElementName = "SolutionPluginAssemblies")]
	public class SolutionPluginAssemblies
	{
		[XmlElement(ElementName = "PluginAssembly")]
		public PluginAssembly PluginAssembly { get; set; }
	}

	[XmlRoot(ElementName = "SdkMessageProcessingStep")]
	public class SdkMessageProcessingStep
	{
		[XmlElement(ElementName = "SdkMessageId")]
		public string SdkMessageId { get; set; }
		[XmlElement(ElementName = "PluginTypeName")]
		public string PluginTypeName { get; set; }
		[XmlElement(ElementName = "PluginTypeId")]
		public string PluginTypeId { get; set; }
		[XmlElement(ElementName = "PrimaryEntity")]
		public string PrimaryEntity { get; set; }
		[XmlElement(ElementName = "AsyncAutoDelete")]
		public string AsyncAutoDelete { get; set; }
		[XmlElement(ElementName = "Description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "FilteringAttributes")]
		public string FilteringAttributes { get; set; }
		[XmlElement(ElementName = "InvocationSource")]
		public string InvocationSource { get; set; }
		[XmlElement(ElementName = "Mode")]
		public string Mode { get; set; }
		[XmlElement(ElementName = "Rank")]
		public string Rank { get; set; }
		[XmlElement(ElementName = "EventHandlerTypeCode")]
		public string EventHandlerTypeCode { get; set; }
		[XmlElement(ElementName = "Stage")]
		public string Stage { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "IsHidden")]
		public string IsHidden { get; set; }
		[XmlElement(ElementName = "SupportedDeployment")]
		public string SupportedDeployment { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "SdkMessageProcessingStepImages")]
		public string SdkMessageProcessingStepImages { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "SdkMessageProcessingStepId")]
		public string SdkMessageProcessingStepId { get; set; }
	}

	[XmlRoot(ElementName = "SdkMessageProcessingSteps")]
	public class SdkMessageProcessingSteps
	{
		[XmlElement(ElementName = "SdkMessageProcessingStep")]
		public List<SdkMessageProcessingStep> SdkMessageProcessingStep { get; set; }
	}

	[XmlRoot(ElementName = "SubArea")]
	public class SubArea
	{
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "Icon")]
		public string Icon { get; set; }
		[XmlAttribute(AttributeName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlAttribute(AttributeName = "Entity")]
		public string Entity { get; set; }
		[XmlAttribute(AttributeName = "Client")]
		public string Client { get; set; }
		[XmlAttribute(AttributeName = "AvailableOffline")]
		public string AvailableOffline { get; set; }
		[XmlAttribute(AttributeName = "PassParams")]
		public string PassParams { get; set; }
		[XmlAttribute(AttributeName = "Sku")]
		public string Sku { get; set; }
		[XmlAttribute(AttributeName = "VectorIcon")]
		public string VectorIcon { get; set; }
		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }
	}

	[XmlRoot(ElementName = "Group")]
	public class Group
	{
		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }
		[XmlElement(ElementName = "SubArea")]
		public List<SubArea> SubArea { get; set; }
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "ResourceId")]
		public string ResourceId { get; set; }
		[XmlAttribute(AttributeName = "DescriptionResourceId")]
		public string DescriptionResourceId { get; set; }
		[XmlAttribute(AttributeName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlAttribute(AttributeName = "IsProfile")]
		public string IsProfile { get; set; }
		[XmlAttribute(AttributeName = "ToolTipResourseId")]
		public string ToolTipResourseId { get; set; }
	}

	[XmlRoot(ElementName = "Area")]
	public class Area
	{
		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }
		[XmlElement(ElementName = "Group")]
		public Group Group { get; set; }
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "ResourceId")]
		public string ResourceId { get; set; }
		[XmlAttribute(AttributeName = "DescriptionResourceId")]
		public string DescriptionResourceId { get; set; }
		[XmlAttribute(AttributeName = "ShowGroups")]
		public string ShowGroups { get; set; }
		[XmlAttribute(AttributeName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
	}

	[XmlRoot(ElementName = "SiteMap")]
	public class SiteMap
	{
		[XmlElement(ElementName = "Area")]
		public Area Area { get; set; }
		[XmlAttribute(AttributeName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
	}

	[XmlRoot(ElementName = "AppModuleSiteMap")]
	public class AppModuleSiteMap
	{
		[XmlElement(ElementName = "SiteMapUniqueName")]
		public string SiteMapUniqueName { get; set; }
		[XmlElement(ElementName = "EnableCollapsibleGroups")]
		public string EnableCollapsibleGroups { get; set; }
		[XmlElement(ElementName = "ShowHome")]
		public string ShowHome { get; set; }
		[XmlElement(ElementName = "ShowPinned")]
		public string ShowPinned { get; set; }
		[XmlElement(ElementName = "ShowRecents")]
		public string ShowRecents { get; set; }
		[XmlElement(ElementName = "SiteMap")]
		public SiteMap SiteMap { get; set; }
		[XmlElement(ElementName = "LocalizedNames")]
		public LocalizedNames LocalizedNames { get; set; }
	}

	[XmlRoot(ElementName = "AppModuleSiteMaps")]
	public class AppModuleSiteMaps
	{
		[XmlElement(ElementName = "AppModuleSiteMap")]
		public List<AppModuleSiteMap> AppModuleSiteMap { get; set; }
	}

	[XmlRoot(ElementName = "AppModuleComponent")]
	public class AppModuleComponent
	{
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "schemaName")]
		public string SchemaName { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "AppModuleComponents")]
	public class AppModuleComponents
	{
		[XmlElement(ElementName = "AppModuleComponent")]
		public List<AppModuleComponent> AppModuleComponent { get; set; }
	}

	[XmlRoot(ElementName = "AppModuleRoleMaps")]
	public class AppModuleRoleMaps
	{
		[XmlElement(ElementName = "Role")]
		public List<Role> Role { get; set; }
	}

	[XmlRoot(ElementName = "canvasappid")]
	public class Canvasappid
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "appelement")]
	public class Appelement
	{
		[XmlElement(ElementName = "canvasappid")]
		public Canvasappid Canvasappid { get; set; }
		[XmlElement(ElementName = "iscustomizable")]
		public string Iscustomizable { get; set; }
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "uniquename")]
		public string Uniquename { get; set; }
	}

	[XmlRoot(ElementName = "appelements")]
	public class Appelements
	{
		[XmlElement(ElementName = "appelement")]
		public List<Appelement> Appelement { get; set; }
	}

	[XmlRoot(ElementName = "AppModule")]
	public class AppModule
	{
		[XmlElement(ElementName = "UniqueName")]
		public string UniqueName { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "WebResourceId")]
		public string WebResourceId { get; set; }
		[XmlElement(ElementName = "OptimizedFor")]
		public string OptimizedFor { get; set; }
		[XmlElement(ElementName = "statecode")]
		public string Statecode { get; set; }
		[XmlElement(ElementName = "statuscode")]
		public string Statuscode { get; set; }
		[XmlElement(ElementName = "FormFactor")]
		public string FormFactor { get; set; }
		[XmlElement(ElementName = "ClientType")]
		public string ClientType { get; set; }
		[XmlElement(ElementName = "NavigationType")]
		public string NavigationType { get; set; }
		[XmlElement(ElementName = "AppModuleComponents")]
		public AppModuleComponents AppModuleComponents { get; set; }
		[XmlElement(ElementName = "AppModuleRoleMaps")]
		public AppModuleRoleMaps AppModuleRoleMaps { get; set; }
		[XmlElement(ElementName = "LocalizedNames")]
		public LocalizedNames LocalizedNames { get; set; }
		[XmlElement(ElementName = "appelements")]
		public Appelements Appelements { get; set; }
	}

	[XmlRoot(ElementName = "AppModules")]
	public class AppModules
	{
		[XmlElement(ElementName = "AppModule")]
		public List<AppModule> AppModule { get; set; }
	}

	[XmlRoot(ElementName = "GalleryItemId")]
	public class GalleryItemId
	{
		[XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string Nil { get; set; }
	}

	[XmlRoot(ElementName = "EmbeddedApp")]
	public class EmbeddedApp
	{
		[XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string Nil { get; set; }
	}

	[XmlRoot(ElementName = "CanvasApp")]
	public class CanvasApp
	{
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "AppVersion")]
		public string AppVersion { get; set; }
		[XmlElement(ElementName = "Status")]
		public string Status { get; set; }
		[XmlElement(ElementName = "CreatedByClientVersion")]
		public string CreatedByClientVersion { get; set; }
		[XmlElement(ElementName = "MinClientVersion")]
		public string MinClientVersion { get; set; }
		[XmlElement(ElementName = "Tags")]
		public string Tags { get; set; }
		[XmlElement(ElementName = "IsCdsUpgraded")]
		public string IsCdsUpgraded { get; set; }
		[XmlElement(ElementName = "GalleryItemId")]
		public GalleryItemId GalleryItemId { get; set; }
		[XmlElement(ElementName = "BackgroundColor")]
		public string BackgroundColor { get; set; }
		[XmlElement(ElementName = "DisplayName")]
		public string DisplayName { get; set; }
		[XmlElement(ElementName = "AuthorizationReferences")]
		public string AuthorizationReferences { get; set; }
		[XmlElement(ElementName = "ConnectionReferences")]
		public string ConnectionReferences { get; set; }
		[XmlElement(ElementName = "DatabaseReferences")]
		public string DatabaseReferences { get; set; }
		[XmlElement(ElementName = "AppComponents")]
		public string AppComponents { get; set; }
		[XmlElement(ElementName = "AppComponentDependencies")]
		public string AppComponentDependencies { get; set; }
		[XmlElement(ElementName = "CanConsumeAppPass")]
		public string CanConsumeAppPass { get; set; }
		[XmlElement(ElementName = "CanvasAppType")]
		public string CanvasAppType { get; set; }
		[XmlElement(ElementName = "BypassConsent")]
		public string BypassConsent { get; set; }
		[XmlElement(ElementName = "AdminControlBypassConsent")]
		public string AdminControlBypassConsent { get; set; }
		[XmlElement(ElementName = "EmbeddedApp")]
		public EmbeddedApp EmbeddedApp { get; set; }
		[XmlElement(ElementName = "IntroducedVersion")]
		public string IntroducedVersion { get; set; }
		[XmlElement(ElementName = "CdsDependencies")]
		public string CdsDependencies { get; set; }
		[XmlElement(ElementName = "IsCustomizable")]
		public string IsCustomizable { get; set; }
		[XmlElement(ElementName = "BackgroundImageUri")]
		public string BackgroundImageUri { get; set; }
		[XmlElement(ElementName = "DocumentUri")]
		public string DocumentUri { get; set; }
		[XmlElement(ElementName = "Description")]
		public Description Description { get; set; }
		[XmlElement(ElementName = "CommitMessage")]
		public CommitMessage CommitMessage { get; set; }
		[XmlElement(ElementName = "Publisher")]
		public Publisher Publisher { get; set; }
	}

	[XmlRoot(ElementName = "CommitMessage")]
	public class CommitMessage
	{
		[XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string Nil { get; set; }
	}

	[XmlRoot(ElementName = "Publisher")]
	public class Publisher
	{
		[XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string Nil { get; set; }
	}

	[XmlRoot(ElementName = "CanvasApps")]
	public class CanvasApps
	{
		[XmlElement(ElementName = "CanvasApp")]
		public List<CanvasApp> CanvasApp { get; set; }
	}

	[XmlRoot(ElementName = "connectionreference")]
	public class Connectionreference
	{
		[XmlElement(ElementName = "connectionreferencedisplayname")]
		public string Connectionreferencedisplayname { get; set; }
		[XmlElement(ElementName = "connectorid")]
		public string Connectorid { get; set; }
		[XmlElement(ElementName = "iscustomizable")]
		public string Iscustomizable { get; set; }
		[XmlElement(ElementName = "statecode")]
		public string Statecode { get; set; }
		[XmlElement(ElementName = "statuscode")]
		public string Statuscode { get; set; }
		[XmlAttribute(AttributeName = "connectionreferencelogicalname")]
		public string Connectionreferencelogicalname { get; set; }
	}

	[XmlRoot(ElementName = "connectionreferences")]
	public class Connectionreferences
	{
		[XmlElement(ElementName = "connectionreference")]
		public List<Connectionreference> Connectionreference { get; set; }
	}

	[XmlRoot(ElementName = "Languages")]
	public class Languages
	{
		[XmlElement(ElementName = "Language")]
		public string Language { get; set; }
	}

	[XmlRoot(ElementName = "ImportExportXml")]
	public class ImportExportXml
	{
		[XmlElement(ElementName = "Entities")]
		public Entities Entities { get; set; }
		[XmlElement(ElementName = "Roles")]
		public Roles Roles { get; set; }
		[XmlElement(ElementName = "Workflows")]
		public Workflows Workflows { get; set; }
		[XmlElement(ElementName = "FieldSecurityProfiles")]
		public string FieldSecurityProfiles { get; set; }
		[XmlElement(ElementName = "Templates")]
		public string Templates { get; set; }
		[XmlElement(ElementName = "EntityMaps")]
		public string EntityMaps { get; set; }
		[XmlElement(ElementName = "EntityRelationships")]
		public EntityRelationships EntityRelationships { get; set; }
		[XmlElement(ElementName = "OrganizationSettings")]
		public string OrganizationSettings { get; set; }
		[XmlElement(ElementName = "optionsets")]
		public Optionsets Optionsets { get; set; }
		[XmlElement(ElementName = "WebResources")]
		public WebResources WebResources { get; set; }
		[XmlElement(ElementName = "CustomControls")]
		public CustomControls CustomControls { get; set; }
		[XmlElement(ElementName = "SolutionPluginAssemblies")]
		public SolutionPluginAssemblies SolutionPluginAssemblies { get; set; }
		[XmlElement(ElementName = "SdkMessageProcessingSteps")]
		public SdkMessageProcessingSteps SdkMessageProcessingSteps { get; set; }
		[XmlElement(ElementName = "AppModuleSiteMaps")]
		public AppModuleSiteMaps AppModuleSiteMaps { get; set; }
		[XmlElement(ElementName = "AppModules")]
		public AppModules AppModules { get; set; }
		[XmlElement(ElementName = "EntityDataProviders")]
		public string EntityDataProviders { get; set; }
		[XmlElement(ElementName = "CanvasApps")]
		public CanvasApps CanvasApps { get; set; }
		[XmlElement(ElementName = "connectionreferences")]
		public Connectionreferences Connectionreferences { get; set; }
		[XmlElement(ElementName = "Languages")]
		public Languages Languages { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
	}
	
}
