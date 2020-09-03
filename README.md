# JoinIT

Goal: To write a pet project and get acquainted with what i will have to work on to join sprints and complete tasks/fix bugs. Also Pet Project must include CRUD operations.

Ideas: 

Create an application of IT-courses that will include payment system of courses itself, joining teams of students, assign tasks on a platform, group students by courses and etc.

Functional Requirements:

models - окремо, repository - окремо, Unity Container, привітальне анімоване вікно, яке ховається і появляється головне вікно, на головному скрині зверху ribbon, окремою табою або знизу справа вікно з настройками, щоб можна було міняти мову і щоб можна було змінити розмір тексту, який буде оновлюватися в real-time, буде скрін, щоб додати і едіти інформацію про студента, який заходить і це буде те саме вікно для додавання і едіта, тут робим валідацію через через інтерфейс IDataErrorInfo. Головний скрін - під риббоном буде таб контрол (по курсах (декілька фільтрів - комбобокс) і під ними буде датагрид який матиме пару колонок вік, спеціальність і тд). В Рібоні має бути створити новий курс, оновити курс і тд. Додаткова опція - прикріпити список студентів. Репозиторій обов'язково асинхронний. Всюди де виконується асинхронний виклик треба буде взаємодіяти з UI (преролл - анімація). Обов'язково MVVM і окремий солушин юніт тести. Юзати 5 версію шарпів


Non-Functional Requirements:

Create private project on Github with git repo and do all the development here
Add as a collaborator Viktor Shyshka
It should be possible to compile application right after cloning the repo
The solution must include unit tests and loggers. All test should pass. Make sure that test have any sense. All tests must be written in another solution.
Detailed instructions on how to set up a solution including dependencies and how to make it running must be provided as a markdown read.me file in the root of repo.
Xaml code should be written without any designer code and using extension “Kill the WPF designer”
Application must use MVVM architecture pattern.



1. Created Template
2. Created 2 windows
3. Created Model
4. Created Repository
5. Created "Create new course Tab"
6. Created courses tabs windows
7. Added DataGrid to show courses related to tab
8. Added combobox with 4 filter options
9. Added search with data template and text box
10. Added search with data template and Date Picker
11. Added spinner data preload 
12. Added Change Language Window
