/* Developer:
 * James Camacho
 *
 * File Name:
 * Index.js
 *
 *
 * Main Functionality:
 * Handle all Controller calls and Single Page Script options
 *
 * Version: 1.0
 *
 * Last Edited : 11/9/19
 */

function changeUser(user, id) {
    document.getElementById("userDropDown").innerHTML = "User(" + user.innerHTML + ")";
    $.ajax({
        url: '/Project/all',
        type: 'GET',
        data: { id: id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (json) {
            $("table").find("tr:gt(0)").remove();
            var tr;
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');
                var startDate = new Date(parseInt(json[i].startDate.substr(6)));
                var endDate = new Date(parseInt(json[i].endate.substr(6)));
                tr.append("<td>" + json[i].projectId + "</td>");
                tr.append("<td>" + startDate + "</td>");
                if (Math.sign(json[i].timetoStart) == -1) {
                    tr.append("<td>Started</td>");
                }
                else {
                    tr.append("<td>" + json[i].timetoStart + "</td>");
                }
                
                tr.append("<td>" + endDate + "</td>");
                tr.append("<td>" + json[i].credits + "</td>");
                tr.append("<td>" + json[i].status + "</td>");

                $('table').append(tr);
            }
        }
        });
}