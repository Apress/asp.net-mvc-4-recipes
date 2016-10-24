CREATE TABLE webpages_UsersInRoles (
                        UserId                                  int                 NOT NULL,
                        RoleId                                  int                 NOT NULL,
                        PRIMARY KEY (UserId, RoleId),
                        CONSTRAINT fk_UserId FOREIGN KEY (UserId) REFERENCES [Artist]([ArtistId]),
                        CONSTRAINT fk_RoleId FOREIGN KEY (RoleId) REFERENCES webpages_Roles(RoleId) )
