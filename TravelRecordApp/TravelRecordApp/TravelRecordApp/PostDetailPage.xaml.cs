﻿using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{	
	public partial class PostDetailPage : ContentPage
	{
        Post selectedPost; 

		public PostDetailPage (Post selectedPost)
		{
			InitializeComponent ();

            this.selectedPost = selectedPost;

            ExperienceEntry.Text = selectedPost.Experience;
		}

        void UpdateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            selectedPost.Experience = ExperienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successful updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
                }
            }
        }

        void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successful deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
                }
            }

        }
    }
}

