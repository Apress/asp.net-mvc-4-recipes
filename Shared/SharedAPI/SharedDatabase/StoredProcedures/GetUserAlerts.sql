create proc [dbo].[GetUserAlerts]
(
@ArtistId int
)
as
set nocount on
-- select the alerts for acoustic
SELECT distinct a.[AlertId]
      ,a.[Headline]
      ,a.[Summary]
      ,a.[ArtistId]
      ,a.[ActorDisplayName]
      ,a.[ActorUrl]
      ,a.[ActorAvatarUrl]
      ,a.[AlertUrl]
      ,a.[AlertAddedDate]
      ,a.[ClickCount]
      ,a.[AlertDate]
      ,a.[Category]
      ,a.[ItemIdentifier]
      ,a.[ItemDetailIdentifier]
  FROM [Alert] a
  inner join alertTag at on a.alertId = at.alertId
  where 
  (a.ArtistId=@ArtistId)
  OR
  at.tag in (
  select distinct Tags from AlertSubscription where ArtistId = @ArtistId
  )
  order by a.AlertDate Desc
  set nocount off
