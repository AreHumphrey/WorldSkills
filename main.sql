Create Table Users
(
    Id          int primary key,
    Email       text unique not null,
    Password    text        not null, -- In sha256 hash!!!
    FirstName   text        not null,
    LastName    text        not null,
    Role        varchar(1) check (Role in ('A', 'C', 'E', 'O', 'P', 'V')),
    Gender      text check (Gender in ('Male', 'Female')),
    DateOfBirth date,
    RegionCode check (1 <= RegionCode <= 100)
);

