const uri = "api/bank";
let banks = null;
function getCount(data) {
    const el = $("#counter");
    let name = "bank";
    if (data) {
        if (data > 1) {
            name = "banks";
        }
        el.text(data + " " + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#banks').empty();
            getCount(data.length);
            $.each(data,
                function (key, item) {
                    const checked = item.isActive ? 'checked' : '';

                    $('<tr><td><input disabled="true" type="checkbox" ' +
                        checked +
                        '></td>' +
                        '<td>' +
                        item.name +
                        '</td>' +
                        '<td>' +
                        item.routingNumber +
                        '</td>' +
                        '<td><button onclick="editItem(' +
                        item.id +
                        ')">Edit</button></td>' +
                        '<td><button onclick="deleteItem(' +
                        item.id +
                        ')">Delete</button></td>' +
                        '</tr>').appendTo($('#banks'));
                });
            banks = data;
        }
    });
}

function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'routingNumber': $('#add-routingNumber').val(),
        'isActive': true
    };
    $.ajax({
        type: 'POST',
        url: uri,
        accepts: 'application\json',
        contentType: 'application\json',
        data: JSON.sringify(item),
        error: function(json, textStatus, errorThrown) {
            alert('here');
        },
        success: function(result) {
            getData();
            $('#add-name').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function(result) {
            getData();
        }
        });
}

function editItem(id) {
    $.each(banks,
        function(key, item) {
            if (item.id == id) {
                $('#edit-name').val(item.name);
                $('#edit-routingNumber').val(item.routingNumber);
                $('#edit-id').val(item.id);
                $('#edit-isActive').val(item.isActive);

            }
        });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit',
    function() {
        const item = {
            'name': $('#edit-name').val(),
            'routingNumber': $('#edit-routingNumber').val(),
            'id': $('#edit-id').val(),
            'isActive': $('#edit-isActive').is(':checked')
        };
        $.ajax({
            type: 'PUT',
            url: uri + '/' + $('#edit-id'),
            accepts: 'application/json',
            contentType: 'application/json',
            data: JSON.stringify(item),
            success: function(result) {
                getdata();
            }
        });
        closeInput();
        return false;
    });
function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}