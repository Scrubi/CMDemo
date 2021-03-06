﻿using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
		private string _firstName = "Tim";
		private string _lastName;
		private PersonModel _selectedPerson;
		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

		public ShellViewModel()
		{
			People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
			People.Add(new PersonModel { FirstName = "Jani", LastName = "Soronen" });
			People.Add(new PersonModel { FirstName = "Donald", LastName = "Trump" });
		}

		public string FirstName 
		{
			get 
			{ 
				return _firstName; 
			}
			set 
			{ 
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string LastName
		{
			get 
			{ 
				return _lastName; 
			}
			set 
			{ 
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string FullName
		{
			get { return $"{ FirstName } { LastName }"; }
			
		}

		public BindableCollection<PersonModel> People
		{
			get 
			{ 
				return _people; 
			}
			set 
			{ 
				_people = value; 
			}
		}

		public PersonModel SelectedPerson
		{
			get 
			{ 
				return _selectedPerson; 
			}
			set 
			{ 
				_selectedPerson = value;
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}

		public bool CanClearText(string firstName, string lastName) 
		{
			return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
		}
		public void ClearText(string firstName, string lastName) 
		{
			FirstName = "";
			LastName = "";
		}

		public void LoadPageOne() 
		{
			ActivateItemAsync(new FirstChildViewModel(), System.Threading.CancellationToken.None);
			
		}

		public void LoadPageTwo()
		{
			ActivateItemAsync(new SecondChildViewModel(), System.Threading.CancellationToken.None);

		}
	}
}
