function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7031/api/statistics', function (data) {
                $('#total_food').text(data.totalFood + " Culinary Delights");
                $('#total_drinks').text(data.totalDrinks + " Drinks");

                $('#statistics_box').removeClass('d-none');

                $('#statistics_btn').text('Hide Statistics')
                $('#statistics_btn').removeClass('btn-outline-info')
                $('#statistics_btn').addClass('btn-outline-danger')
            });
        } else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Show Statistics')
            $('#statistics_btn').removeClass('btn-outline-danger')
            $('#statistics_btn').addClass('btn-outline-info')
        }

    });
}