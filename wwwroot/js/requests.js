$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Session/CheckIfSessionIsActive",
        success: function (response) {
            if (response) {
                $(".end-button").css("display", "inline");
            } else {
                $(".start-button").css("display", "inline");
            }
        },
        failure: function (response) {
            alert("fail");
        },
        error: function (response) {
            alert("err");
        }
    });

    $.ajax({
        type: "GET",
        url: "/Session/GetAllSessions",
        success: function (response) {
            if (response.length != 0) {
                for (var i = 0; i < response.length; i++) {
                    $('.table').append('<tr class=' + response[i].id +'><td>' + response[i].projectName + '</td><td>' + response[i].startDate + '</td><td>' + response[i].endDate + '</td></tr>');
                }
                return;
            }

            $('.table').append('<tr id="no-record"><td></td><td>Nema zapisa</td><td></td></tr>');
        },
        failure: function (response) {
            alert("fail");
        },
        error: function (response) {
            alert("err");
        }
    });
});

$(".start-button").click(function () {
    $.ajax({
        type: "GET",
        url: "/Session/StartSession",
        success: function (response) {
            $(".end-button").css("display", "inline");
            $(".start-button").css("display", "none");
            $("#no-record").css("display", "none");
            $('.table').append('<tr class=' + response.id +'><td>' + response.projectName + '</td><td>' + response.startDate + '</td><td>' + response.endDate + '</td></tr>');
        },
        failure: function (response) {
            alert("fail");
        },
        error: function (response) {
            alert("err");
        }
    });
});

$(".end-button").click(function () {
    Swal.fire({
        title: 'Upsi ime projekta',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Zavrsi za danas',
        showLoaderOnConfirm: true,
        preConfirm: (login) => {
            $.ajax({
                type: "GET",
                data: {
                    ProjectName: login
                },
                url: "/Session/EndSession",
                success: function (response) {
                    console.log(response);
                    $("." + response.id + " td:last").html(response.endDate);
                    $("." + response.id + " td:first").html(response.projectName);
                    $(".end-button").css("display", "none");
                    $(".start-button").css("display", "inline");
                },
                failure: function (response) {
                    alert("fail");
                },
                error: function (response) {
                    alert("err");
                }
            });
        },
        allowOutsideClick: () => !Swal.isLoading()
    })
});