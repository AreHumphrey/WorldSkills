Create Table Users
(
    User_id     int primary key,
    Email       text unique not null check (Email like '%@%.%'),
    Password    text        not null, -- In sha256 hash
    FirstName   text        not null,
    LastName    text        not null,
    Role_id     int references Roles (Role_id),
    Gender      text check (Gender in ('Male', 'Female')),
    DateOfBirth date        not null,
    RegionCode  int references Regions (RegionCode)
);

Create Table Regions
(
    RegionCode int primary key check (1 <= RegionCode <= 100),
    Name       text unique not null,
    Capital    text unique not null,
    Area       text        not null
);

Create Table Roles
(
    Role_id     int primary key,
    Role        varchar(1) check (Role in ('E', 'P', 'C', 'V', 'A', 'O')),
    Description text check ( Description in
                             ('Expert', 'Press', 'Competitor', 'Volunteer', 'Administrator', 'Coordinator'))
);

Create Table Events
(
    Event_id    int primary key,
    Title       text unique not null,
    Description text        not null,
    Dates       date        not null,
    Website     text unique not null
);

Create Table Results
(
    User_id            int primary key,
    Competition_number int  not null,
    Competition_name   text not null,
    Championship_code  int  references Championships(Champ_id),
    Mark               float check (0 <= Mark <= 100),
    Modules            text not null,
    Foreign Key (User_id) References Users (User_id)
);

Create Table Volunteers
(
    Volunteer_id int primary key,
    FirstName    text not null,
    LastName     text not null,
    RegionCode   int references Regions (RegionCode),
    Gender       text check (Gender in ('Male', 'Female'))
);

Create Table Championships --WSI
(
    Champ_id      int primary key,
    Title         text not null,
    Dates         date not null,
    Place         text not null,
    Link          text,
    Address       text,
    Members_count int  not null
);

Create Table Skills
(
    Skill_id int primary key ,
    Name text unique not null,
    WSI text not null,
    Description_RUS text not null,
    Description_EN text not null
);