# TodoList
This is a pretty simple todo list tracker.  It's currently intended to function as a noteboard for 
users to keep track of personal obligations.  It's built on the default MVC5 framework, with some
new functionality I added in there.  I'm using the register/login system built into the default
project.  Signed in users can add new tasks, edit tasks they've created, and change the status of
their tasks.  The task list is grouped by user, with incomplete tasks sorted by deadline and 
finished tasks sorted by completion time.  By default, all tasks from all users are shown, but 
users have the option to hide completed tasks, tasks belonging to other users, or both.  The 
project is seeded with a few example users and tasks.  The login information for them both is 
below.  

- Username: brad
- Password: P4$$w0rd

- Username: OtherGuy
- Password: Zomg!23

There are a lot of improvements that could be made to this project in the future.  Some of the
ones I've thought about include:
- Change the deadline picker on creation and editing to be a calendar/clock picker instead of 
  just a text entry field
- Add dependencies (i.e. Task 1 needs to be finished before Task 2) to both the back end and in 
  the UI
- Allow tasks to be shared between multiple users
- Add an admin role that can create tasks and assign them to other users
