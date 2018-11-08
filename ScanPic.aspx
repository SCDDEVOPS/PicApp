<%@ Page Title="Scan Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ScanPic.aspx.vb" Inherits="ScanPic" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script>
        function img() {
            var C = document.getElementById("<%=FUP.ClientID %>").files.length;
            var ID;
            for (ID = 0; ID < C; ID++) {
                var file = document.getElementById("FUP").files[ID];
                var url = window.URL.createObjectURL(file);
                var fnd = 0;
                var pn = ID + 1;
                var did = "d0" + pn.toString();
                do {
                    did = "d0" + pn.toString();
                    var DV = document.getElementById(did);
                    //alert(did + " is " + DV.style.visibility);
                    if (DV.style.visibility == "hidden") {
                        fnd = 1;
                        did = "d0" + pn.toString();
                        //alert("Found " + did);
                    } else {
                        pn++;
                    }
                    if (pn > 9) { fnd = 1;}
                } while (fnd == 0);
                
                did = "d0" + pn.toString();
                var fid = fctrls[pn];
                var pid = controls[pn];
                var FOB = document.getElementById(fid);
                FOB.files[0] = file;
                document.getElementById(pid).src = url;
                document.getElementById(pid).style.visibility = "visible";
                document.getElementById(did).style.visibility = "visible";

            }
}
    function inputToURL(inputElement) {
        var file = inputElement.files[0];
        return window.URL.createObjectURL(file);
    }

        function onPictureTaken(event) {
		    var sFile = event.target.files[0];
            var reader = new FileReader();
            var pn = 1;
            var fnd = 0;
            var did = "d0" + pn.toString();
            do {
              var DV = document.getElementById(did);
                if (DV.style.visibility == "hidden") {
                    fnd = 1;
                    did = "d0" + pn.toString();
                } else {
                    pn++;
                    did = "d0" + pn.toString();
                }
                if (pn > 9) { fnd = 1;}
            } while (fnd === 0 );
            var pid = "p0" + pn.toString();
            var did = "d0" + pn.toString();
            var fid = "f0" + pn.toString();
		    var imgObj = document.getElementById(pid);
            var DV = document.getElementById(did);
            var FUPL = document.getElementById(fid);

	    reader.onload = function(event){
            imgObj.src = event.target.result;
            
         };

        reader.onloadend = function () {
        };

		 reader.readAsDataURL(sFile);
         DV.style.visibility = "visible";
        }

</script>
    <style>
        .pics {
            table-layout: fixed;
            width: 90%;
            white-space: nowrap;
        }
        .pics td{
            white-space: nowrap;
            width: 25%;
        }
    </style>
   <asp:Panel ID="pnlCamInp" runat="server" >
       <div style="visibility: hidden; height: 1px;">
          <asp:FileUpload runat="server" ID="FUP" ClientIDMode="Static" AutoUpload="true" onchange="submit();" AllowMultiple="true" />
       </div>
   </asp:Panel>
   <asp:Panel ID="pnlbtns" runat="server" Width="292px">
   <table class="bordernone" >
      <tr>
        <td class="bordernone" style="text-align: left; vertical-align: middle;">	  
   	     <Label for="FUP" runat="server">
              <img src="./images/CAP.png" />
	      </label>
	    </td>
        <td class="bordernone">	  
	      <div style="text-align: center; font: 18pt Arial; width: 170px;">
              <asp:Label ID="JOBSHOW" runat="server" Text="Label"></asp:Label>
	      </div>
	    </td>
        <td class="bordernone" style="text-align: right; vertical-align: middle; width: 62px;">	  
           <asp:ImageButton ID="DLImg" runat="server" ImageUrl="~/images/DL.png" BorderStyle="None" />
	    </td>
	   </tr>
	</table>
   </asp:Panel>
   <asp:Panel ID="pnlPicShow" runat="server">
	<table class="pics" >
        <tr><td>
         <asp:ListView ID="LVIEW" runat="server" GroupItemCount="3">
<LayoutTemplate>
            <asp:Placeholder
                id="groupPlaceholder"
                runat="server" />
            </LayoutTemplate>
            <GroupTemplate>
            <div>
            <asp:Placeholder
                id="itemPlaceholder"
                runat="server" />
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <asp:Image
                id="imgPhoto"
                ImageUrl='<%# Container.DataItem %>'
                Width="100px"
                Runat="server" />
        </ItemTemplate>
         </asp:ListView>
            </td>
        </tr>
	</table>
   </asp:Panel>
</asp:Content>
