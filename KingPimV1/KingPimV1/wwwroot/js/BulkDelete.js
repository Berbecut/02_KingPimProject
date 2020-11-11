$(document).ready(function () {

    $('#checkAll').click(function () {
        $('input:checkbox').prop('checked', this.checked);
    });

    $("#deleteBulk").on('click', function (e) {
        getValueUsingParentTag();
    });

    function getValueUsingParentTag() {
        var chkArray = [];

        /* look for all checkboxes in .cards and check if they are checked, and then take their values and push into an array */
        $("input.flo:checked").each(function () {
            chkArray.push($(this).val());
        });

        /* join the array separated by the comma */
        var selected;
        selected = chkArray.join(',');

        /* add selected value to hidden fields if it contains values */
        if (selected.length > 0) {
            $("#productsIdToDelete").val(selected);
            //console.log(selected);
            var value = $("#productsIdToDelete").val();
        }
        else
        {
            alert("Select at least one product");
        }
    }
});