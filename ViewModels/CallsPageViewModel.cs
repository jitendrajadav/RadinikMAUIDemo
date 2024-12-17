using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using RadinikMAUIDemo.Db;
using RadinikMAUIDemo.Models;
using RadinikMAUIDemo.Services;
using System.Collections.ObjectModel;

namespace RadinikMAUIDemo.ViewModels
{
    public partial class CallsPageViewModel : ObservableObject, IQueryAttributable
    {
        RadinikDatabase _database;
        private readonly LocalDatabase? _context;
        private TodoItem todoItem1;

        private readonly TodoService _todoService;

        [ObservableProperty]
        ObservableCollection<Monkey>? monkeys = [];

        [ObservableProperty]
        bool isActivityIndicatorRunning = true;

        public CallsPageViewModel(RadinikDatabase database, TodoService todoService)
        {
            // Unregisters the recipient from a message type
            WeakReferenceMessenger.Default.Unregister<LoggedInUserChangedMessage>(this);

            // Register a message in some module
            WeakReferenceMessenger.Default.Register<LoggedInUserChangedMessage>(this, (r, m) =>
            {
                // Handle the message here, with r being the recipient and m being the
                // input message. Using the recipient passed as input makes it so that
                // the lambda expression doesn't capture "this", improving performance.
            });

            _database = database;

            Task.Run(async () => await PopulateData());
            _todoService = todoService;
        }

        public async Task LoadItemsAsync()
        {
            var items = await _todoService.GetAllTodoItemsAsync();
        }

        public async Task AddItemAsync(string name)
        {
            await _todoService.AddTodoItemAsync(name);
            await LoadItemsAsync();
        }

        private async Task PopulateData()
        {
            await Task.Delay(2000);

            Monkeys.Add(new Monkey
            {
                ImageUrl = "https://www.placemonkeys.com/500/350",
                Location = "Mumbai",
                Name = "Monkey1"
            });

            Monkeys.Add(new Monkey
            {
                ImageUrl = "https://www.placemonkeys.com/500/350",
                Location = "Pune",
                Name = "Monkey2"
            });
            Monkeys.Add(new Monkey
            {
                ImageUrl = "https://www.placemonkeys.com/500/350",
                Location = "Surat",
                Name = "Monkey3"
            });
            Monkeys.Add(new Monkey
            {
                ImageUrl = "https://www.placemonkeys.com/500/350",
                Location = "Banglore",
                Name = "Monkey4"
            });
            Monkeys.Add(new Monkey
            {
                ImageUrl = "https://www.placemonkeys.com/500/350",
                Location = "Banglore",
                Name = "Monkey4"
            });
            Monkeys.Add(new Monkey
            {
                ImageUrl = "https://www.placemonkeys.com/500/350",
                Location = "Banglore",
                Name = "Monkey4"

            });

            IsActivityIndicatorRunning = false;

            //Service Call
            //Monkeys = data.

            TodoItem todoItem = new TodoItem();
            todoItem.Name = "Hello SQL";


            //First approach without EF
            //await _database.SaveItemAsync(todoItem);

            //var items = await _database.GetItemsAsync();

            //Second approach with EF
            try
            {
                //using (var item = new LocalDatabase())
                //{
                //    item.Add(todoItem);

                //    await item.SaveChangesAsync();

                //    var values = item.TodoItems.ToList();
                //}

                await AddItemAsync("Radinik");
                await LoadItemsAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id"))
            {
                try
                {
                    int id = Convert.ToInt32(query["id"]);
                }
                catch (Exception)
                {

                }   
            }
        }
    }



// Create a message
public class LoggedInUserChangedMessage : ValueChangedMessage<User>
    {
        public LoggedInUserChangedMessage(User user) : base(user)
        {
        }
    }
}
