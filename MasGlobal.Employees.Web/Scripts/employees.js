
$("body").on('click', '#query', function (object) {

    const employeeId = $('#employeeId')[0].value;

    $('.table').footable({
        "rows": $.get(`http://localhost:52761/api/Employees${!employeeId ? '' : '?employeeId=' + employeeId}`)
    });
});