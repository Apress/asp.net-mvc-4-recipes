CREATE PROCEDURE [dbo].[u_DeleteArtist]
	@ArtistId int = 0
AS
 begin
 set nocount on
 
 --mark media items owned by this user as deleted
 update Media
 set ArtistId=null,
 IsDeleted=1
 where ArtistId = @ArtistId

 -- delete all songs
 delete from Song
 where SongId in (
 select SongId from PlaylistItem  
 inner join Playlist 
 on (PlayList.PlaylistId = PlaylistItem.PlaylistId)
 where Playlist.ArtistId = @ArtistId)

 delete from PlaylistItem 
 where PlaylistId in (select PlaylistId from Playlist where ArtistId = @ArtistId)


 delete from  Playlist where ArtistId = @ArtistId


 delete from ArtistCollaborationSpaces where ArtistId = @ArtistId
 delete from ArtistBand where ArtistId = @ArtistId
 
 -- remove any orphaned bands, playlist deleted by cascade rule
 delete b
 from  Band b
  left join ArtistBand ab
 ON ab.BandId =  b.BandId
 where ab.BandId IS NULL

 

 set nocount off
 end
