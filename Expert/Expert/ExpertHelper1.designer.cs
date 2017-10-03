﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Expert
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Expert")]
	public partial class ExpertHelperDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKryterium(Kryterium instance);
    partial void UpdateKryterium(Kryterium instance);
    partial void DeleteKryterium(Kryterium instance);
    partial void InsertWynik(Wynik instance);
    partial void UpdateWynik(Wynik instance);
    partial void DeleteWynik(Wynik instance);
    partial void InsertObliczenia(Obliczenia instance);
    partial void UpdateObliczenia(Obliczenia instance);
    partial void DeleteObliczenia(Obliczenia instance);
    partial void InsertWaga(Waga instance);
    partial void UpdateWaga(Waga instance);
    partial void DeleteWaga(Waga instance);
    #endregion
		
		public ExpertHelperDataContext() : 
				base(global::Expert.Properties.Settings.Default.ExpertConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ExpertHelperDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExpertHelperDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExpertHelperDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExpertHelperDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Kryterium> Kryteriums
		{
			get
			{
				return this.GetTable<Kryterium>();
			}
		}
		
		public System.Data.Linq.Table<Wynik> Wyniks
		{
			get
			{
				return this.GetTable<Wynik>();
			}
		}
		
		public System.Data.Linq.Table<Obliczenia> Obliczenias
		{
			get
			{
				return this.GetTable<Obliczenia>();
			}
		}
		
		public System.Data.Linq.Table<Waga> Wagas
		{
			get
			{
				return this.GetTable<Waga>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Kryterium")]
	public partial class Kryterium : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _ID_Rodzica;
		
		private int _ID_Celu;
		
		private string _Nazwa;
		
		private string _Opis;
		
		private System.DateTime _Data_utworzenia;
		
		private int _Liczba_Podkryteriow;
		
		private bool _Czy_Wariant;
		
		private EntitySet<Kryterium> _Kryteriums;
		
		private EntitySet<Wynik> _Wyniks;
		
		private EntitySet<Wynik> _Wyniks1;
		
		private EntitySet<Wynik> _Wyniks2;
		
		private EntitySet<Obliczenia> _Obliczenias;
		
		private EntitySet<Obliczenia> _Obliczenias1;
		
		private EntitySet<Waga> _Wagas;
		
		private EntitySet<Waga> _Wagas1;
		
		private EntitySet<Waga> _Wagas2;
		
		private EntityRef<Kryterium> _Kryterium1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnID_RodzicaChanging(System.Nullable<int> value);
    partial void OnID_RodzicaChanged();
    partial void OnID_CeluChanging(int value);
    partial void OnID_CeluChanged();
    partial void OnNazwaChanging(string value);
    partial void OnNazwaChanged();
    partial void OnOpisChanging(string value);
    partial void OnOpisChanged();
    partial void OnData_utworzeniaChanging(System.DateTime value);
    partial void OnData_utworzeniaChanged();
    partial void OnLiczba_PodkryteriowChanging(int value);
    partial void OnLiczba_PodkryteriowChanged();
    partial void OnCzy_WariantChanging(bool value);
    partial void OnCzy_WariantChanged();
    #endregion
		
		public Kryterium()
		{
			this._Kryteriums = new EntitySet<Kryterium>(new Action<Kryterium>(this.attach_Kryteriums), new Action<Kryterium>(this.detach_Kryteriums));
			this._Wyniks = new EntitySet<Wynik>(new Action<Wynik>(this.attach_Wyniks), new Action<Wynik>(this.detach_Wyniks));
			this._Wyniks1 = new EntitySet<Wynik>(new Action<Wynik>(this.attach_Wyniks1), new Action<Wynik>(this.detach_Wyniks1));
			this._Wyniks2 = new EntitySet<Wynik>(new Action<Wynik>(this.attach_Wyniks2), new Action<Wynik>(this.detach_Wyniks2));
			this._Obliczenias = new EntitySet<Obliczenia>(new Action<Obliczenia>(this.attach_Obliczenias), new Action<Obliczenia>(this.detach_Obliczenias));
			this._Obliczenias1 = new EntitySet<Obliczenia>(new Action<Obliczenia>(this.attach_Obliczenias1), new Action<Obliczenia>(this.detach_Obliczenias1));
			this._Wagas = new EntitySet<Waga>(new Action<Waga>(this.attach_Wagas), new Action<Waga>(this.detach_Wagas));
			this._Wagas1 = new EntitySet<Waga>(new Action<Waga>(this.attach_Wagas1), new Action<Waga>(this.detach_Wagas1));
			this._Wagas2 = new EntitySet<Waga>(new Action<Waga>(this.attach_Wagas2), new Action<Waga>(this.detach_Wagas2));
			this._Kryterium1 = default(EntityRef<Kryterium>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Rodzica", DbType="Int")]
		public System.Nullable<int> ID_Rodzica
		{
			get
			{
				return this._ID_Rodzica;
			}
			set
			{
				if ((this._ID_Rodzica != value))
				{
					if (this._Kryterium1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_RodzicaChanging(value);
					this.SendPropertyChanging();
					this._ID_Rodzica = value;
					this.SendPropertyChanged("ID_Rodzica");
					this.OnID_RodzicaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Celu", DbType="Int NOT NULL")]
		public int ID_Celu
		{
			get
			{
				return this._ID_Celu;
			}
			set
			{
				if ((this._ID_Celu != value))
				{
					this.OnID_CeluChanging(value);
					this.SendPropertyChanging();
					this._ID_Celu = value;
					this.SendPropertyChanged("ID_Celu");
					this.OnID_CeluChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nazwa", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nazwa
		{
			get
			{
				return this._Nazwa;
			}
			set
			{
				if ((this._Nazwa != value))
				{
					this.OnNazwaChanging(value);
					this.SendPropertyChanging();
					this._Nazwa = value;
					this.SendPropertyChanged("Nazwa");
					this.OnNazwaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opis", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if ((this._Opis != value))
				{
					this.OnOpisChanging(value);
					this.SendPropertyChanging();
					this._Opis = value;
					this.SendPropertyChanged("Opis");
					this.OnOpisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data_utworzenia", DbType="DateTime NOT NULL")]
		public System.DateTime Data_utworzenia
		{
			get
			{
				return this._Data_utworzenia;
			}
			set
			{
				if ((this._Data_utworzenia != value))
				{
					this.OnData_utworzeniaChanging(value);
					this.SendPropertyChanging();
					this._Data_utworzenia = value;
					this.SendPropertyChanged("Data_utworzenia");
					this.OnData_utworzeniaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Liczba_Podkryteriow", DbType="Int NOT NULL")]
		public int Liczba_Podkryteriow
		{
			get
			{
				return this._Liczba_Podkryteriow;
			}
			set
			{
				if ((this._Liczba_Podkryteriow != value))
				{
					this.OnLiczba_PodkryteriowChanging(value);
					this.SendPropertyChanging();
					this._Liczba_Podkryteriow = value;
					this.SendPropertyChanged("Liczba_Podkryteriow");
					this.OnLiczba_PodkryteriowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Czy_Wariant", DbType="Bit NOT NULL")]
		public bool Czy_Wariant
		{
			get
			{
				return this._Czy_Wariant;
			}
			set
			{
				if ((this._Czy_Wariant != value))
				{
					this.OnCzy_WariantChanging(value);
					this.SendPropertyChanging();
					this._Czy_Wariant = value;
					this.SendPropertyChanged("Czy_Wariant");
					this.OnCzy_WariantChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Kryterium", Storage="_Kryteriums", ThisKey="ID", OtherKey="ID_Rodzica")]
		public EntitySet<Kryterium> Kryteriums
		{
			get
			{
				return this._Kryteriums;
			}
			set
			{
				this._Kryteriums.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Wynik", Storage="_Wyniks", ThisKey="ID", OtherKey="KryteriumGlowne")]
		public EntitySet<Wynik> Wyniks
		{
			get
			{
				return this._Wyniks;
			}
			set
			{
				this._Wyniks.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Wynik1", Storage="_Wyniks1", ThisKey="ID", OtherKey="Kryterium1")]
		public EntitySet<Wynik> Wyniks1
		{
			get
			{
				return this._Wyniks1;
			}
			set
			{
				this._Wyniks1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Wynik2", Storage="_Wyniks2", ThisKey="ID", OtherKey="Kryterium2")]
		public EntitySet<Wynik> Wyniks2
		{
			get
			{
				return this._Wyniks2;
			}
			set
			{
				this._Wyniks2.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Obliczenia", Storage="_Obliczenias", ThisKey="ID", OtherKey="ID_Kryterium")]
		public EntitySet<Obliczenia> Obliczenias
		{
			get
			{
				return this._Obliczenias;
			}
			set
			{
				this._Obliczenias.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Obliczenia1", Storage="_Obliczenias1", ThisKey="ID", OtherKey="ID_Celu")]
		public EntitySet<Obliczenia> Obliczenias1
		{
			get
			{
				return this._Obliczenias1;
			}
			set
			{
				this._Obliczenias1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Waga", Storage="_Wagas", ThisKey="ID", OtherKey="Kryterium1")]
		public EntitySet<Waga> Wagas
		{
			get
			{
				return this._Wagas;
			}
			set
			{
				this._Wagas.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Waga1", Storage="_Wagas1", ThisKey="ID", OtherKey="Kryterium2")]
		public EntitySet<Waga> Wagas1
		{
			get
			{
				return this._Wagas1;
			}
			set
			{
				this._Wagas1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Waga2", Storage="_Wagas2", ThisKey="ID", OtherKey="KryteriumGlowne")]
		public EntitySet<Waga> Wagas2
		{
			get
			{
				return this._Wagas2;
			}
			set
			{
				this._Wagas2.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Kryterium", Storage="_Kryterium1", ThisKey="ID_Rodzica", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium1
		{
			get
			{
				return this._Kryterium1.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium1.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium1.Entity = null;
						previousValue.Kryteriums.Remove(this);
					}
					this._Kryterium1.Entity = value;
					if ((value != null))
					{
						value.Kryteriums.Add(this);
						this._ID_Rodzica = value.ID;
					}
					else
					{
						this._ID_Rodzica = default(Nullable<int>);
					}
					this.SendPropertyChanged("Kryterium1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Kryteriums(Kryterium entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium1 = this;
		}
		
		private void detach_Kryteriums(Kryterium entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium1 = null;
		}
		
		private void attach_Wyniks(Wynik entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium = this;
		}
		
		private void detach_Wyniks(Wynik entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium = null;
		}
		
		private void attach_Wyniks1(Wynik entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium3 = this;
		}
		
		private void detach_Wyniks1(Wynik entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium3 = null;
		}
		
		private void attach_Wyniks2(Wynik entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium4 = this;
		}
		
		private void detach_Wyniks2(Wynik entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium4 = null;
		}
		
		private void attach_Obliczenias(Obliczenia entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium = this;
		}
		
		private void detach_Obliczenias(Obliczenia entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium = null;
		}
		
		private void attach_Obliczenias1(Obliczenia entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium1 = this;
		}
		
		private void detach_Obliczenias1(Obliczenia entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium1 = null;
		}
		
		private void attach_Wagas(Waga entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium = this;
		}
		
		private void detach_Wagas(Waga entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium = null;
		}
		
		private void attach_Wagas1(Waga entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium3 = this;
		}
		
		private void detach_Wagas1(Waga entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium3 = null;
		}
		
		private void attach_Wagas2(Waga entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium4 = this;
		}
		
		private void detach_Wagas2(Waga entity)
		{
			this.SendPropertyChanging();
			entity.Kryterium4 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Wynik")]
	public partial class Wynik : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _KryteriumGlowne;
		
		private int _Kryterium1;
		
		private int _Kryterium2;
		
		private double _Waga;
		
		private EntityRef<Kryterium> _Kryterium;
		
		private EntityRef<Kryterium> _Kryterium3;
		
		private EntityRef<Kryterium> _Kryterium4;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnKryteriumGlowneChanging(int value);
    partial void OnKryteriumGlowneChanged();
    partial void OnKryterium1Changing(int value);
    partial void OnKryterium1Changed();
    partial void OnKryterium2Changing(int value);
    partial void OnKryterium2Changed();
    partial void OnWagaChanging(double value);
    partial void OnWagaChanged();
    #endregion
		
		public Wynik()
		{
			this._Kryterium = default(EntityRef<Kryterium>);
			this._Kryterium3 = default(EntityRef<Kryterium>);
			this._Kryterium4 = default(EntityRef<Kryterium>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KryteriumGlowne", DbType="Int NOT NULL")]
		public int KryteriumGlowne
		{
			get
			{
				return this._KryteriumGlowne;
			}
			set
			{
				if ((this._KryteriumGlowne != value))
				{
					if (this._Kryterium.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKryteriumGlowneChanging(value);
					this.SendPropertyChanging();
					this._KryteriumGlowne = value;
					this.SendPropertyChanged("KryteriumGlowne");
					this.OnKryteriumGlowneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kryterium1", DbType="Int NOT NULL")]
		public int Kryterium1
		{
			get
			{
				return this._Kryterium1;
			}
			set
			{
				if ((this._Kryterium1 != value))
				{
					if (this._Kryterium3.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKryterium1Changing(value);
					this.SendPropertyChanging();
					this._Kryterium1 = value;
					this.SendPropertyChanged("Kryterium1");
					this.OnKryterium1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kryterium2", DbType="Int NOT NULL")]
		public int Kryterium2
		{
			get
			{
				return this._Kryterium2;
			}
			set
			{
				if ((this._Kryterium2 != value))
				{
					if (this._Kryterium4.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKryterium2Changing(value);
					this.SendPropertyChanging();
					this._Kryterium2 = value;
					this.SendPropertyChanged("Kryterium2");
					this.OnKryterium2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Waga", DbType="Float NOT NULL")]
		public double Waga
		{
			get
			{
				return this._Waga;
			}
			set
			{
				if ((this._Waga != value))
				{
					this.OnWagaChanging(value);
					this.SendPropertyChanging();
					this._Waga = value;
					this.SendPropertyChanged("Waga");
					this.OnWagaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Wynik", Storage="_Kryterium", ThisKey="KryteriumGlowne", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium
		{
			get
			{
				return this._Kryterium.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium.Entity = null;
						previousValue.Wyniks.Remove(this);
					}
					this._Kryterium.Entity = value;
					if ((value != null))
					{
						value.Wyniks.Add(this);
						this._KryteriumGlowne = value.ID;
					}
					else
					{
						this._KryteriumGlowne = default(int);
					}
					this.SendPropertyChanged("Kryterium");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Wynik1", Storage="_Kryterium3", ThisKey="Kryterium1", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium3
		{
			get
			{
				return this._Kryterium3.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium3.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium3.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium3.Entity = null;
						previousValue.Wyniks1.Remove(this);
					}
					this._Kryterium3.Entity = value;
					if ((value != null))
					{
						value.Wyniks1.Add(this);
						this._Kryterium1 = value.ID;
					}
					else
					{
						this._Kryterium1 = default(int);
					}
					this.SendPropertyChanged("Kryterium3");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Wynik2", Storage="_Kryterium4", ThisKey="Kryterium2", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium4
		{
			get
			{
				return this._Kryterium4.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium4.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium4.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium4.Entity = null;
						previousValue.Wyniks2.Remove(this);
					}
					this._Kryterium4.Entity = value;
					if ((value != null))
					{
						value.Wyniks2.Add(this);
						this._Kryterium2 = value.ID;
					}
					else
					{
						this._Kryterium2 = default(int);
					}
					this.SendPropertyChanged("Kryterium4");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Obliczenia")]
	public partial class Obliczenia : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _ID_Celu;
		
		private int _ID_Kryterium;
		
		private string _Wyniki;
		
		private EntityRef<Kryterium> _Kryterium;
		
		private EntityRef<Kryterium> _Kryterium1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnID_CeluChanging(int value);
    partial void OnID_CeluChanged();
    partial void OnID_KryteriumChanging(int value);
    partial void OnID_KryteriumChanged();
    partial void OnWynikiChanging(string value);
    partial void OnWynikiChanged();
    #endregion
		
		public Obliczenia()
		{
			this._Kryterium = default(EntityRef<Kryterium>);
			this._Kryterium1 = default(EntityRef<Kryterium>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Celu", DbType="Int NOT NULL")]
		public int ID_Celu
		{
			get
			{
				return this._ID_Celu;
			}
			set
			{
				if ((this._ID_Celu != value))
				{
					if (this._Kryterium1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_CeluChanging(value);
					this.SendPropertyChanging();
					this._ID_Celu = value;
					this.SendPropertyChanged("ID_Celu");
					this.OnID_CeluChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Kryterium", DbType="Int NOT NULL")]
		public int ID_Kryterium
		{
			get
			{
				return this._ID_Kryterium;
			}
			set
			{
				if ((this._ID_Kryterium != value))
				{
					if (this._Kryterium.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_KryteriumChanging(value);
					this.SendPropertyChanging();
					this._ID_Kryterium = value;
					this.SendPropertyChanged("ID_Kryterium");
					this.OnID_KryteriumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wyniki", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Wyniki
		{
			get
			{
				return this._Wyniki;
			}
			set
			{
				if ((this._Wyniki != value))
				{
					this.OnWynikiChanging(value);
					this.SendPropertyChanging();
					this._Wyniki = value;
					this.SendPropertyChanged("Wyniki");
					this.OnWynikiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Obliczenia", Storage="_Kryterium", ThisKey="ID_Kryterium", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium
		{
			get
			{
				return this._Kryterium.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium.Entity = null;
						previousValue.Obliczenias.Remove(this);
					}
					this._Kryterium.Entity = value;
					if ((value != null))
					{
						value.Obliczenias.Add(this);
						this._ID_Kryterium = value.ID;
					}
					else
					{
						this._ID_Kryterium = default(int);
					}
					this.SendPropertyChanged("Kryterium");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Obliczenia1", Storage="_Kryterium1", ThisKey="ID_Celu", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium1
		{
			get
			{
				return this._Kryterium1.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium1.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium1.Entity = null;
						previousValue.Obliczenias1.Remove(this);
					}
					this._Kryterium1.Entity = value;
					if ((value != null))
					{
						value.Obliczenias1.Add(this);
						this._ID_Celu = value.ID;
					}
					else
					{
						this._ID_Celu = default(int);
					}
					this.SendPropertyChanged("Kryterium1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Waga")]
	public partial class Waga : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _KryteriumGlowne;
		
		private int _Kryterium1;
		
		private int _Kryterium2;
		
		private double _Waga1;
		
		private EntityRef<Kryterium> _Kryterium;
		
		private EntityRef<Kryterium> _Kryterium3;
		
		private EntityRef<Kryterium> _Kryterium4;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnKryteriumGlowneChanging(int value);
    partial void OnKryteriumGlowneChanged();
    partial void OnKryterium1Changing(int value);
    partial void OnKryterium1Changed();
    partial void OnKryterium2Changing(int value);
    partial void OnKryterium2Changed();
    partial void OnWaga1Changing(double value);
    partial void OnWaga1Changed();
    #endregion
		
		public Waga()
		{
			this._Kryterium = default(EntityRef<Kryterium>);
			this._Kryterium3 = default(EntityRef<Kryterium>);
			this._Kryterium4 = default(EntityRef<Kryterium>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KryteriumGlowne", DbType="Int NOT NULL")]
		public int KryteriumGlowne
		{
			get
			{
				return this._KryteriumGlowne;
			}
			set
			{
				if ((this._KryteriumGlowne != value))
				{
					if (this._Kryterium4.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKryteriumGlowneChanging(value);
					this.SendPropertyChanging();
					this._KryteriumGlowne = value;
					this.SendPropertyChanged("KryteriumGlowne");
					this.OnKryteriumGlowneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kryterium1", DbType="Int NOT NULL")]
		public int Kryterium1
		{
			get
			{
				return this._Kryterium1;
			}
			set
			{
				if ((this._Kryterium1 != value))
				{
					if (this._Kryterium.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKryterium1Changing(value);
					this.SendPropertyChanging();
					this._Kryterium1 = value;
					this.SendPropertyChanged("Kryterium1");
					this.OnKryterium1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kryterium2", DbType="Int NOT NULL")]
		public int Kryterium2
		{
			get
			{
				return this._Kryterium2;
			}
			set
			{
				if ((this._Kryterium2 != value))
				{
					if (this._Kryterium3.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnKryterium2Changing(value);
					this.SendPropertyChanging();
					this._Kryterium2 = value;
					this.SendPropertyChanged("Kryterium2");
					this.OnKryterium2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Waga", Storage="_Waga1", DbType="Float NOT NULL")]
		public double Waga1
		{
			get
			{
				return this._Waga1;
			}
			set
			{
				if ((this._Waga1 != value))
				{
					this.OnWaga1Changing(value);
					this.SendPropertyChanging();
					this._Waga1 = value;
					this.SendPropertyChanged("Waga1");
					this.OnWaga1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Waga", Storage="_Kryterium", ThisKey="Kryterium1", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium
		{
			get
			{
				return this._Kryterium.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium.Entity = null;
						previousValue.Wagas.Remove(this);
					}
					this._Kryterium.Entity = value;
					if ((value != null))
					{
						value.Wagas.Add(this);
						this._Kryterium1 = value.ID;
					}
					else
					{
						this._Kryterium1 = default(int);
					}
					this.SendPropertyChanged("Kryterium");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Waga1", Storage="_Kryterium3", ThisKey="Kryterium2", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium3
		{
			get
			{
				return this._Kryterium3.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium3.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium3.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium3.Entity = null;
						previousValue.Wagas1.Remove(this);
					}
					this._Kryterium3.Entity = value;
					if ((value != null))
					{
						value.Wagas1.Add(this);
						this._Kryterium2 = value.ID;
					}
					else
					{
						this._Kryterium2 = default(int);
					}
					this.SendPropertyChanged("Kryterium3");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kryterium_Waga2", Storage="_Kryterium4", ThisKey="KryteriumGlowne", OtherKey="ID", IsForeignKey=true)]
		public Kryterium Kryterium4
		{
			get
			{
				return this._Kryterium4.Entity;
			}
			set
			{
				Kryterium previousValue = this._Kryterium4.Entity;
				if (((previousValue != value) 
							|| (this._Kryterium4.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Kryterium4.Entity = null;
						previousValue.Wagas2.Remove(this);
					}
					this._Kryterium4.Entity = value;
					if ((value != null))
					{
						value.Wagas2.Add(this);
						this._KryteriumGlowne = value.ID;
					}
					else
					{
						this._KryteriumGlowne = default(int);
					}
					this.SendPropertyChanged("Kryterium4");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
