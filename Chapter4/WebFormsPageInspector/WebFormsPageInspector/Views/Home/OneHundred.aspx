<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>One Hundred</title>
</head>
<body>
    <div>
        Here is a list of numbers and whether they are odd or even.
        <ul>
        <%foreach (var item in Model)
          { %>
            <li><%= item %></li>
        <% } %>
        </ul>
    </div>
</body>
</html>
