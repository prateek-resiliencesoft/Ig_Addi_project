<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AutoLikeOrders.aspx.cs" Inherits="SocialPanel.Admin.AutoLikeOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function () {

        var data = "";
        $.ajax({
            type: "POST",
            url: "../JquerPost.aspx/GetNonCompletedLikeOrdersForAdmin",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                data = eval(result);
                //alert(data);
                data = JSON.stringify(data);
                //alert(data);
                var theme = "";
                //aert(data);

                //data = '[{"Id":26,"URL":"http://facebook.com/Test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383997127063)\/","OrderStatus":"Processing","OrderId":"126679788171f9b21a","StartPoint":1,"EndPoint":101,"OrderType":"PageLike","UpdateDate":"\/Date(1383997127083)\/","EmployeeName":"test"},{"Id":27,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383989876760)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":1,"EndPoint":101,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":28,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383989878017)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":200,"EndPoint":300,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":29,"URL":"https://facebook.com/test","Amount":101,"UserName":"test","OrderDate":"\/Date(1383989879093)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":1,"EndPoint":102,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":30,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383989880153)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":201,"EndPoint":301,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":31,"URL":"https://facebook.com/test","Amount":1000,"UserName":"test","OrderDate":"\/Date(1383989881213)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":250,"EndPoint":1250,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":32,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383989882310)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":214,"EndPoint":314,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":33,"URL":"https://facebook.com/test","Amount":10,"UserName":"test","OrderDate":"\/Date(1383989883363)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":1,"EndPoint":11,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":34,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383989884433)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":100,"EndPoint":200,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":35,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383989885480)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":14,"EndPoint":114,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":36,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"\/Date(1383989886573)\/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":52,"EndPoint":152,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null}]';//'{"d":[{"Id":26,"URL":"http://facebook.com/Test","Amount":100,"UserName":"test","OrderDate":"Date(1383997127063)","OrderStatus":"Processing","OrderId":"126679788171f9b21a","StartPoint":1,"EndPoint":101,"OrderType":"PageLike","UpdateDate":"/Date(1383997127083)/","EmployeeName":"test"},{"Id":27,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"/Date(1383989876760)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":1,"EndPoint":101,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":28,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"/Date(1383989878017)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":200,"EndPoint":300,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":29,"URL":"https://facebook.com/test","Amount":101,"UserName":"test","OrderDate":"/Date(1383989879093)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":1,"EndPoint":102,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":30,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"/Date(1383989880153)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":201,"EndPoint":301,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":31,"URL":"https://facebook.com/test","Amount":1000,"UserName":"test","OrderDate":"/Date(1383989881213)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":250,"EndPoint":1250,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":32,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"/Date(1383989882310)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":214,"EndPoint":314,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":33,"URL":"https://facebook.com/test","Amount":10,"UserName":"test","OrderDate":"/Date(1383989883363)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":1,"EndPoint":11,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":34,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"/Date(1383989884433)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":100,"EndPoint":200,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":35,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"/Date(1383989885480)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":14,"EndPoint":114,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null},{"Id":36,"URL":"https://facebook.com/test","Amount":100,"UserName":"test","OrderDate":"/Date(1383989886573)/","OrderStatus":"Pending","OrderId":"1086060656bdf3efdb","StartPoint":52,"EndPoint":152,"OrderType":"Comment Like","UpdateDate":null,"EmployeeName":null}]}';
                //alert(data);
                // prepare the data
                var source =
            {
                datatype: "json",
                datafields: [
                    { name: 'OrderId', type: 'int' },
                    { name: 'Url', type: 'string' },
                    { name: 'Amount', type: 'int' },
                    { name: 'OrderDate', type: 'date' },
                    { name: 'StartPoint', type: 'int' },
                    { name: 'EndPoint', type: 'int' },
                   { name: 'OrderStatus', type: 'string' }
                ],
                localdata: data,
                pagesize: 20,
                pager: function (pagenum, pagesize, oldpagenum) {
                    // callback called when a page or page size is changed.
                },

                deleterow: function (rowid, commit) {
                    // synchronize with the server - send delete command
                    // call commit with parameter true if the synchronization with the server is successful
                    //and with parameter false if the synchronization failed.
                    //alert("temp");
                    var TempData = "";
                    $.post("../JquerPost.aspx/DeleteOrder", { id: dataRecord.OrderId })
                        .done(function (TempData) {
                            alert("Data Loaded: " + TempData);
                            commit(true);
                        });


                },
                updaterow: function (rowid, rowdata, commit) {
                    // synchronize with the server - send update command
                    // call commit with parameter true if the synchronization with the server is successful 
                    // and with parameter false if the synchronization failed.
                    commit(true);
                }
            };
                //alert("1");
                var statusRender = function (row, columnfield, value) {

                    if (value == 'Completed') {
                        return '<span class="label label-success">Completed</span>';
                    }
                    else if (value == 'Processing') {
                        return '<span class="label label-warning">Processing</span>';
                    }
                    else if (value == 'Pending') {
                        return '<span class="label label-info">Pending</span>';
                    }
                    else if (value == 'Private') {
                        return '<span class="label label-important">Private</span>';
                    }
                    else {
                        return '<span class="label label-important">' + value + '</span>';
                    }
                }

                var cellsrenderer = function (row, column, value, defaultHtml) {
                    if (row == 0 || row == 2 || row == 5) {
                        var element = $(defaultHtml);
                        element.css({ 'background-color': 'Yellow', 'width': '100%', 'height': '100%', 'margin': '0px' });
                        return element[0].outerHTML;
                    }
                    return defaultHtml;
                }
                var editOrder = function (row, column, value, defaultHtml) {
                    var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', row);
                    //return '<a href="/Admin/Order.aspx?id=' + dataRecord.OrderId + '" target="_blank"/>Edit</a>'
                    return '<a class="btn btn-info" href="/Admin/Order.aspx?id=' + dataRecord.OrderId + '" target="_blank"><i class="icon-edit icon-white"></i>Edit</a>'
                }

                var hrefUrl = function (row, column, value, defaultHtml) {
                    var dataRecord = $("#jqxgrid").jqxGrid('getrowdata', row);
                    return '<a href=' + value + ' target="_blank"/>' + value + '</a>'
                }

                var dataAdapter = new $.jqx.dataAdapter(source);
                //alert(dataAdapter);
                $("#jqxgrid").jqxGrid(
            {
                width: 1020,
                rowsheight: 30,
                source: dataAdapter,
                theme: theme,
                selectionmode: 'multiplerowsextended',
                sortable: true,
                showstatusbar: true,
                statusbarheight: 50,
                showaggregates: true,
                pageable: true,
                autoheight: true,
                columnsresize: true,
                filterable: true,
                enabletooltips: false,
                //                renderstatusbar: function (statusbar) {
                //                    // appends buttons to the status bar.
                //                    var container = $("<div style='overflow: hidden; position: relative; margin: 5px;'></div>");
                //                    var addButton = $("<div style='float: left; margin-left: 5px;'><img style='position: relative; margin-top: 2px;' src='Styles/Jqx/images/add.png'/><span style='margin-left: 4px; position: relative; top: -3px;'>Add</span></div>");
                //                    var deleteButton = $("<div style='float: left; margin-left: 5px;'><img style='position: relative; margin-top: 2px;' src='Styles/Jqx/images/close.png'/><span style='margin-left: 4px; position: relative; top: -3px;'>Delete</span></div>");
                //                    var reloadButton = $("<div style='float: left; margin-left: 5px;'><img style='position: relative; margin-top: 2px;' src='Styles/Jqx/images/refresh.png'/><span style='margin-left: 4px; position: relative; top: -3px;'>Reload</span></div>");
                //                    var searchButton = $("<div style='float: left; margin-left: 5px;'><img style='position: relative; margin-top: 2px;' src='Styles/Jqx/images/search.png'/><span style='margin-left: 4px; position: relative; top: -3px;'>Find</span></div>");
                //                    container.append(addButton);
                //                    container.append(deleteButton);
                //                    container.append(reloadButton);
                //                    container.append(searchButton);
                //                    statusbar.append(container);
                //                    addButton.jqxButton({ theme: theme, width: 60, height: 20 });
                //                    deleteButton.jqxButton({ theme: theme, width: 65, height: 20 });
                //                    reloadButton.jqxButton({ theme: theme, width: 65, height: 20 });
                //                    searchButton.jqxButton({ theme: theme, width: 50, height: 20 });
                //                    // add new row.
                //                    addButton.click(function (event) {
                //                        var datarow = generatedata(1);
                //                        $("#jqxgrid").jqxGrid('addrow', null, datarow[0]);
                //                    });
                //                    // delete selected row.
                //                    deleteButton.click(function (event) {
                //                        var selectedrowindex = $("#jqxgrid").jqxGrid('getselectedrowindex');
                //                        var rowscount = $("#jqxgrid").jqxGrid('getdatainformation').rowscount;
                //                        var id = $("#jqxgrid").jqxGrid('getrowid', selectedrowindex);
                //                        $("#jqxgrid").jqxGrid('deleterow', id);
                //                    });
                //                    // reload grid data.
                //                    reloadButton.click(function (event) {
                //                        $("#jqxgrid").jqxGrid({ source: getAdapter() });
                //                    });
                //                    // search for a record.
                //                    searchButton.click(function (event) {
                //                        var offset = $("#jqxgrid").offset();
                //                        $("#jqxwindow").jqxWindow('open');
                //                        $("#jqxwindow").jqxWindow('move', offset.left + 30, offset.top + 30);
                //                    });
                //                },
                columns: [
                    { text: 'Edit', datafield: 'Edit', width: 62, cellsrenderer: editOrder },
                    { text: 'OrderId', datafield: 'OrderId', width: 100 },
                    { text: 'Url', datafield: 'Url', width: 350, cellsrenderer: hrefUrl },
                    { text: 'Amount', datafield: 'Amount', width: 60, aggregates: ['sum'] },
                    { text: 'Order Date', datafield: 'OrderDate', width: 200, cellsformat: 'M/d/yyyy h:mm:ss tt' },
                    { text: 'Start', datafield: 'StartPoint', width: 70 },
                    { text: 'End', datafield: 'EndPoint', width: 70 },
                    { text: 'Status', datafield: 'OrderStatus', width: 110, cellsrenderer: statusRender }

                ]
            });

                $("#deleterowbutton").jqxButton({ theme: theme });

                // delete row.
                $("#deleterowbutton").on('click', function () {
                    var selectedrowindex = $("#jqxgrid").jqxGrid('getselectedrowindex');
                    var rowscount = $("#jqxgrid").jqxGrid('getdatainformation').rowscount;
                    if (selectedrowindex >= 0 && selectedrowindex < rowscount) {
                        var id = $("#jqxgrid").jqxGrid('getrowid', selectedrowindex);
                        //alert(id);
                        var commit = $("#jqxgrid").jqxGrid('deleterow', id);
                    }
                });

                $("#jqxgrid").on('cellendedit', function (event) {
                    var args = event.args;
                    var strmessage = "Event Type: cellendedit, Column: " + args.datafield + ", Row: " + (1 + args.rowindex) + ", Value: " + args.value;
                    //alert(strmessage);
                    //$("#cellendeditevent").text("Event Type: cellendedit, Column: " + args.datafield + ", Row: " + (1 + args.rowindex) + ", Value: " + args.value);
                });



                //            $('#events').jqxPanel({ width: 300, height: 300, theme: theme });

                //            $("#jqxgrid").on("pagechanged", function (event) {
                //                $("#eventslog").css('display', 'block');
                //                if ($("#events").find('.logged').length >= 5) {
                //                    $("#events").jqxPanel('clearcontent');
                //                }

                //                var args = event.args;
                //                var eventData = "pagechanged <div>Page:" + args.pagenum + ", Page Size: " + args.pagesize + "</div>";
                //                $('#events').jqxPanel('prepend', '<div class="logged" style="margin-top: 5px;">' + eventData + '</div>');

                //                // get page information.
                //                var paginginformation = $("#jqxgrid").jqxGrid('getpaginginformation');
                //                $('#paginginfo').html("<div style='margin-top: 5px;'>Page:" + paginginformation.pagenum + ", Page Size: " + paginginformation.pagesize + ", Pages Count: " + paginginformation.pagescount + "</div>");
                //            });

                //            $("#jqxgrid").on("pagesizechanged", function (event) {
                //                $("#eventslog").css('display', 'block');
                //                $("#events").jqxPanel('clearcontent');

                //                var args = event.args;
                //                var eventData = "pagesizechanged <div>Page:" + args.pagenum + ", Page Size: " + args.pagesize + ", Old Page Size: " + args.oldpagesize + "</div>";
                //                $('#events').jqxPanel('prepend', '<div style="margin-top: 5px;">' + eventData + '</div>');

                //                // get page information.          
                //                var paginginformation = $("#jqxgrid").jqxGrid('getpaginginformation');
                //                $('#paginginfo').html("<div style='margin-top: 5px;'>Page:" + paginginformation.pagenum + ", Page Size: " + paginginformation.pagesize + ", Pages Count: " + paginginformation.pagescount + "</div>");
                //            });

            }
        })
    });
    </script>
    <style>
        .green:not(.jqx-grid-cell-hover):not(.jqx-grid-cell-selected), .jqx-widget .green:not(.jqx-grid-cell-hover):not(.jqx-grid-cell-selected)
        {
            color: black;
            background-color: #b6ff00;
        }
        .yellow:not(.jqx-grid-cell-hover):not(.jqx-grid-cell-selected), .jqx-widget .yellow:not(.jqx-grid-cell-hover):not(.jqx-grid-cell-selected)
        {
            color: black;
            background-color: yellow;
        }
        .red:not(.jqx-grid-cell-hover):not(.jqx-grid-cell-selected), .jqx-widget .red:not(.jqx-grid-cell-hover):not(.jqx-grid-cell-selected)
        {
            color: black;
            background-color: #e83636;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content" class="span10">
        <!-- content starts -->
        <div>
            <ul class="breadcrumb">
                <li><a href="#">Home</a> <span class="divider">/</span> </li>
                <li><a href="#">Auto Like Non Completed Orders</a> </li>
            </ul>
        </div>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header well" data-original-title>
                    <h2>
                        <i class="icon-edit"></i>Auto Like  Non Completed Orders</h2>
                    <div class="box-icon">
                        <%--<a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>--%>
                        <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                        <%--<a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>--%>
                        
                    </div>
                </div>
                <div class="box-content">
                  <div id='jqxWidget' style="margin-left: 20px;">
        <div id="jqxgrid">
        </div>
        <div id="cellbegineditevent">
        </div>
        <div style="margin-top: 10px;">
           <%-- <input id="deleterowbutton" type="button" value="Delete Selected Row" />--%>
        </div>
    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
            <!-- content ends -->
        </div>
    </div>
</asp:Content>
