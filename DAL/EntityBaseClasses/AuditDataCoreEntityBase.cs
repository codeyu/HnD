﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Data;
using System.Xml.Serialization;
using SD.HnD.DAL;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.RelationClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity base class which represents the base class for the entity 'AuditDataCore'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class AuditDataCoreEntityBase : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private AuditActionEntity _auditAction;
		private bool	_alwaysFetchAuditAction, _alreadyFetchedAuditAction, _auditActionReturnsNewIfNotFound;
		private UserEntity _userAudited;
		private bool	_alwaysFetchUserAudited, _alreadyFetchedUserAudited, _userAuditedReturnsNewIfNotFound;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name AuditAction</summary>
			public static readonly string AuditAction = "AuditAction";
			/// <summary>Member name UserAudited</summary>
			public static readonly string UserAudited = "UserAudited";



		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AuditDataCoreEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public AuditDataCoreEntityBase()
		{
			InitClassEmpty(null);
		}

	
		/// <summary>CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		public AuditDataCoreEntityBase(System.Int32 auditDataID)
		{
			InitClassFetch(auditDataID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public AuditDataCoreEntityBase(System.Int32 auditDataID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(auditDataID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="validator">The custom validator object for this AuditDataCoreEntity</param>
		public AuditDataCoreEntityBase(System.Int32 auditDataID, IValidator validator)
		{
			InitClassFetch(auditDataID, validator, null);
		}
	

		/// <summary>Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AuditDataCoreEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{


			_auditAction = (AuditActionEntity)info.GetValue("_auditAction", typeof(AuditActionEntity));
			if(_auditAction!=null)
			{
				_auditAction.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_auditActionReturnsNewIfNotFound = info.GetBoolean("_auditActionReturnsNewIfNotFound");
			_alwaysFetchAuditAction = info.GetBoolean("_alwaysFetchAuditAction");
			_alreadyFetchedAuditAction = info.GetBoolean("_alreadyFetchedAuditAction");
			_userAudited = (UserEntity)info.GetValue("_userAudited", typeof(UserEntity));
			if(_userAudited!=null)
			{
				_userAudited.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_userAuditedReturnsNewIfNotFound = info.GetBoolean("_userAuditedReturnsNewIfNotFound");
			_alwaysFetchUserAudited = info.GetBoolean("_alwaysFetchUserAudited");
			_alreadyFetchedUserAudited = info.GetBoolean("_alreadyFetchedUserAudited");

			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AuditDataCoreFieldIndex)fieldIndex)
			{
				case AuditDataCoreFieldIndex.AuditActionID:
					DesetupSyncAuditAction(true, false);
					_alreadyFetchedAuditAction = false;
					break;
				case AuditDataCoreFieldIndex.UserID:
					DesetupSyncUserAudited(true, false);
					_alreadyFetchedUserAudited = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
		
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{


			_alreadyFetchedAuditAction = (_auditAction != null);
			_alreadyFetchedUserAudited = (_userAudited != null);

		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return AuditDataCoreEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AuditAction":
					toReturn.Add(AuditDataCoreEntity.Relations.AuditActionEntityUsingAuditActionID);
					break;
				case "UserAudited":
					toReturn.Add(AuditDataCoreEntity.Relations.UserEntityUsingUserID);
					break;



				default:

					break;				
			}
			return toReturn;
		}

		/// <summary> Gets the inheritance info for this entity, if applicable (it's then overriden) or null if not.</summary>
		/// <returns>InheritanceInfo object if this entity is in a hierarchy of type TargetPerEntity, or null otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override IInheritanceInfo GetInheritanceInfo()
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataCoreEntity", false);
		}
		
		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public  static IPredicateExpression GetEntityTypeFilter()
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("AuditDataCoreEntity", false);
		}
		
		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public  static IPredicateExpression GetEntityTypeFilter(bool negate)
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("AuditDataCoreEntity", negate);
		}

		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{


			info.AddValue("_auditAction", (!this.MarkedForDeletion?_auditAction:null));
			info.AddValue("_auditActionReturnsNewIfNotFound", _auditActionReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchAuditAction", _alwaysFetchAuditAction);
			info.AddValue("_alreadyFetchedAuditAction", _alreadyFetchedAuditAction);
			info.AddValue("_userAudited", (!this.MarkedForDeletion?_userAudited:null));
			info.AddValue("_userAuditedReturnsNewIfNotFound", _userAuditedReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchUserAudited", _alwaysFetchUserAudited);
			info.AddValue("_alreadyFetchedUserAudited", _alreadyFetchedUserAudited);

			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity entity)
		{
			switch(propertyName)
			{
				case "AuditAction":
					_alreadyFetchedAuditAction = true;
					this.AuditAction = (AuditActionEntity)entity;
					break;
				case "UserAudited":
					_alreadyFetchedUserAudited = true;
					this.UserAudited = (UserEntity)entity;
					break;



				default:

					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "AuditAction":
					SetupSyncAuditAction(relatedEntity);
					break;
				case "UserAudited":
					SetupSyncUserAudited(relatedEntity);
					break;


				default:

					break;
			}
		}
		
		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "AuditAction":
					DesetupSyncAuditAction(false, true);
					break;
				case "UserAudited":
					DesetupSyncUserAudited(false, true);
					break;


				default:

					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();


			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_auditAction!=null)
			{
				toReturn.Add(_auditAction);
			}
			if(_userAudited!=null)
			{
				toReturn.Add(_userAudited);
			}


			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();


			return toReturn;
		}

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned 
		/// could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static  AuditDataCoreEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 auditDataID, Context contextToUse)
		{
			return FetchPolymorphic(transactionToUse, auditDataID, contextToUse, null);
		}
				
		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned 
		/// could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static  AuditDataCoreEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 auditDataID, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			AuditDataCoreDAO dao = new AuditDataCoreDAO();
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(SD.HnD.DAL.EntityType.AuditDataCoreEntity);
			fields[(int)AuditDataCoreFieldIndex.AuditDataID].ForcedCurrentValueWrite(auditDataID);
			return (AuditDataCoreEntity)dao.FetchExistingPolymorphic(transactionToUse, fields, contextToUse, excludedIncludedFields);
		}
		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditDataID)
		{
			return FetchUsingPK(auditDataID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditDataID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(auditDataID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditDataID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(auditDataID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditDataID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(auditDataID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.AuditDataID, null, null, null);
		}

		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AuditDataCoreFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AuditDataCoreFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}
		
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the SD.HnD.DAL.EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("AuditDataCoreEntity", ((SD.HnD.DAL.EntityType)typeOfEntity).ToString());
		}
				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AuditDataCoreRelations().GetAllRelations();
		}




		/// <summary> Retrieves the related entity of type 'AuditActionEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'AuditActionEntity' which is related to this entity.</returns>
		public AuditActionEntity GetSingleAuditAction()
		{
			return GetSingleAuditAction(false);
		}

		/// <summary> Retrieves the related entity of type 'AuditActionEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'AuditActionEntity' which is related to this entity.</returns>
		public virtual AuditActionEntity GetSingleAuditAction(bool forceFetch)
		{
			if( ( !_alreadyFetchedAuditAction || forceFetch || _alwaysFetchAuditAction) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(AuditDataCoreEntity.Relations.AuditActionEntityUsingAuditActionID);

				AuditActionEntity newEntity = new AuditActionEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.AuditActionID);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (AuditActionEntity)base.ActiveContext.Get(newEntity);
					}
					this.AuditAction = newEntity;
				}
				else
				{
					if(_auditActionReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_auditAction == null)))
						{
							this.AuditAction = newEntity;
						}
					}
					else
					{
						this.AuditAction = null;
					}
				}
				_alreadyFetchedAuditAction = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _auditAction;
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSingleUserAudited()
		{
			return GetSingleUserAudited(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleUserAudited(bool forceFetch)
		{
			if( ( !_alreadyFetchedUserAudited || forceFetch || _alwaysFetchUserAudited) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(AuditDataCoreEntity.Relations.UserEntityUsingUserID);

				UserEntity newEntity = new UserEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.UserID);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (UserEntity)base.ActiveContext.Get(newEntity);
					}
					this.UserAudited = newEntity;
				}
				else
				{
					if(_userAuditedReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_userAudited == null)))
						{
							this.UserAudited = newEntity;
						}
					}
					else
					{
						this.UserAudited = null;
					}
				}
				_alreadyFetchedUserAudited = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _userAudited;
		}


		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			AuditDataCoreDAO dao = (AuditDataCoreDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_auditAction!=null)
			{
				_auditAction.ActiveContext = base.ActiveContext;
			}
			if(_userAudited!=null)
			{
				_userAudited.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			AuditDataCoreDAO dao = (AuditDataCoreDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			AuditDataCoreDAO dao = (AuditDataCoreDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction, updateRestriction);
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		protected virtual void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			base.Fields = CreateFields();
			base.IsNew=true;
			base.Validator = validatorToUse;

			InitClassMembers();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(SD.HnD.DAL.EntityType.AuditDataCoreEntity);
		}
		
		/// <summary>Creates a new transaction object</summary>
		/// <param name="levelOfIsolation">The level of isolation.</param>
		/// <param name="name">The name.</param>
		protected override ITransaction CreateTransaction( IsolationLevel levelOfIsolation, string name )
		{
			return new Transaction(levelOfIsolation, name);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AuditAction", _auditAction);
			toReturn.Add("UserAudited", _userAudited);



			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="validator">The validator object for this AuditDataCoreEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 auditDataID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			base.Validator = validator;
			InitClassMembers();
			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(auditDataID, prefetchPathToUse, null, null);
			base.IsNew = !wasSuccesful;

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{


			_auditAction = null;
			_auditActionReturnsNewIfNotFound = true;
			_alwaysFetchAuditAction = false;
			_alreadyFetchedAuditAction = false;
			_userAudited = null;
			_userAuditedReturnsNewIfNotFound = true;
			_alwaysFetchUserAudited = false;
			_alreadyFetchedUserAudited = false;


			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AuditDataID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AuditActionID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AuditedOn", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _auditAction</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAuditAction(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _auditAction, new PropertyChangedEventHandler( OnAuditActionPropertyChanged ), "AuditAction", AuditDataCoreEntity.Relations.AuditActionEntityUsingAuditActionID, true, signalRelatedEntity, "AuditDataCore", resetFKFields, new int[] { (int)AuditDataCoreFieldIndex.AuditActionID } );		
			_auditAction = null;
		}
		
		/// <summary> setups the sync logic for member _auditAction</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAuditAction(IEntity relatedEntity)
		{
			if(_auditAction!=relatedEntity)
			{		
				DesetupSyncAuditAction(true, true);
				_auditAction = (AuditActionEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _auditAction, new PropertyChangedEventHandler( OnAuditActionPropertyChanged ), "AuditAction", AuditDataCoreEntity.Relations.AuditActionEntityUsingAuditActionID, true, ref _alreadyFetchedAuditAction, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAuditActionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _userAudited</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUserAudited(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _userAudited, new PropertyChangedEventHandler( OnUserAuditedPropertyChanged ), "UserAudited", AuditDataCoreEntity.Relations.UserEntityUsingUserID, true, signalRelatedEntity, "LoggedAudits", resetFKFields, new int[] { (int)AuditDataCoreFieldIndex.UserID } );		
			_userAudited = null;
		}
		
		/// <summary> setups the sync logic for member _userAudited</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUserAudited(IEntity relatedEntity)
		{
			if(_userAudited!=relatedEntity)
			{		
				DesetupSyncUserAudited(true, true);
				_userAudited = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _userAudited, new PropertyChangedEventHandler( OnUserAuditedPropertyChanged ), "UserAudited", AuditDataCoreEntity.Relations.UserEntityUsingUserID, true, ref _alreadyFetchedUserAudited, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserAuditedPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="auditDataID">PK value for AuditDataCore which data should be fetched into this AuditDataCore object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 auditDataID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)AuditDataCoreFieldIndex.AuditDataID].ForcedCurrentValueWrite(auditDataID);
				dao.FetchExisting(this, base.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (base.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}


		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateAuditDataCoreDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new AuditDataCoreEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AuditDataCoreRelations Relations
		{
			get	{ return new AuditDataCoreRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AuditAction' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAuditAction
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AuditActionCollection(),
					(IEntityRelation)GetRelationsForField("AuditAction")[0], (int)SD.HnD.DAL.EntityType.AuditDataCoreEntity, (int)SD.HnD.DAL.EntityType.AuditActionEntity, 0, null, null, null, "AuditAction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserAudited
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(),
					(IEntityRelation)GetRelationsForField("UserAudited")[0], (int)SD.HnD.DAL.EntityType.AuditDataCoreEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, null, "UserAudited", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "AuditDataCoreEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AuditDataCoreEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return AuditDataCoreEntity.FieldsCustomProperties;}
		}

		/// <summary> The AuditDataID property of the Entity AuditDataCore<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AuditDataCore"."AuditDataID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AuditDataID
		{
			get { return (System.Int32)GetValue((int)AuditDataCoreFieldIndex.AuditDataID, true); }
			set	{ SetValue((int)AuditDataCoreFieldIndex.AuditDataID, value, true); }
		}
		/// <summary> The AuditActionID property of the Entity AuditDataCore<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AuditDataCore"."AuditActionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AuditActionID
		{
			get { return (System.Int32)GetValue((int)AuditDataCoreFieldIndex.AuditActionID, true); }
			set	{ SetValue((int)AuditDataCoreFieldIndex.AuditActionID, value, true); }
		}
		/// <summary> The UserID property of the Entity AuditDataCore<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AuditDataCore"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 UserID
		{
			get { return (System.Int32)GetValue((int)AuditDataCoreFieldIndex.UserID, true); }
			set	{ SetValue((int)AuditDataCoreFieldIndex.UserID, value, true); }
		}
		/// <summary> The AuditedOn property of the Entity AuditDataCore<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "AuditDataCore"."AuditedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 23, 3, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AuditedOn
		{
			get { return (System.DateTime)GetValue((int)AuditDataCoreFieldIndex.AuditedOn, true); }
			set	{ SetValue((int)AuditDataCoreFieldIndex.AuditedOn, value, true); }
		}



		/// <summary> Gets / sets related entity of type 'AuditActionEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleAuditAction()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual AuditActionEntity AuditAction
		{
			get	{ return GetSingleAuditAction(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAuditAction(value);
				}
				else
				{
					if(value==null)
					{
						if(_auditAction != null)
						{
							_auditAction.UnsetRelatedEntity(this, "AuditDataCore");
						}
					}
					else
					{
						if(_auditAction!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "AuditDataCore");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for AuditAction. When set to true, AuditAction is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AuditAction is accessed. You can always execute
		/// a forced fetch by calling GetSingleAuditAction(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAuditAction
		{
			get	{ return _alwaysFetchAuditAction; }
			set	{ _alwaysFetchAuditAction = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property AuditAction already has been fetched. Setting this property to false when AuditAction has been fetched
		/// will set AuditAction to null as well. Setting this property to true while AuditAction hasn't been fetched disables lazy loading for AuditAction</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAuditAction
		{
			get { return _alreadyFetchedAuditAction;}
			set 
			{
				if(_alreadyFetchedAuditAction && !value)
				{
					this.AuditAction = null;
				}
				_alreadyFetchedAuditAction = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property AuditAction is not found
		/// in the database. When set to true, AuditAction will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool AuditActionReturnsNewIfNotFound
		{
			get	{ return _auditActionReturnsNewIfNotFound; }
			set { _auditActionReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleUserAudited()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual UserEntity UserAudited
		{
			get	{ return GetSingleUserAudited(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncUserAudited(value);
				}
				else
				{
					if(value==null)
					{
						if(_userAudited != null)
						{
							_userAudited.UnsetRelatedEntity(this, "LoggedAudits");
						}
					}
					else
					{
						if(_userAudited!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "LoggedAudits");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for UserAudited. When set to true, UserAudited is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserAudited is accessed. You can always execute
		/// a forced fetch by calling GetSingleUserAudited(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserAudited
		{
			get	{ return _alwaysFetchUserAudited; }
			set	{ _alwaysFetchUserAudited = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserAudited already has been fetched. Setting this property to false when UserAudited has been fetched
		/// will set UserAudited to null as well. Setting this property to true while UserAudited hasn't been fetched disables lazy loading for UserAudited</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserAudited
		{
			get { return _alreadyFetchedUserAudited;}
			set 
			{
				if(_alreadyFetchedUserAudited && !value)
				{
					this.UserAudited = null;
				}
				_alreadyFetchedUserAudited = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property UserAudited is not found
		/// in the database. When set to true, UserAudited will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool UserAuditedReturnsNewIfNotFound
		{
			get	{ return _userAuditedReturnsNewIfNotFound; }
			set { _userAuditedReturnsNewIfNotFound = value; }	
		}



		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.TargetPerEntity;}
		}
		
		/// <summary>Returns the SD.HnD.DAL.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)SD.HnD.DAL.EntityType.AuditDataCoreEntity; }
		}
		#endregion

		
		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
