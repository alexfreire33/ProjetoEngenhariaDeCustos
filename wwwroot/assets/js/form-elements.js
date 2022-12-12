$(document).ready(function () {

    $("#date").mask("00/00/0000",{placeholder:"mm/dd/yyyy"});

    $("#phone").mask("(000) 000-0000");
    
    $("#phoneext").mask("(000) 000-0000? x00000");

    $("#tin").mask("00-0000000");

    $("#ssn").mask("000-00-0000");
    
                
    $("#percent").mask("00%");
    
    $("#currency").mask("$000,000,000.00");
    
    $("#productkey").mask("a*-000-a000");
    
    //            seleect2
    $(".name_search").select2({
        placeholder: "Select"
    });

    $(".multi").select2();

    $(".mintwo").select2({
        minimumInputLength: 2
    });

    $(".maxallowed").select2({
        maximumSelectionSize: 3
    });

    $('#pre-selected-options').multiSelect();
    
    //            date plugin
    $('.datepicker').datepicker()

    $('#date-popup input').datepicker({});

    $('#date-popup-group .input-group.date').datepicker({});

    $('#date-popup-startend .input-group.date').datepicker({
        startDate: "03/17/2015",
        endDate: "03/25/2015"
    });

    $('#date-disabled .input-group.date').datepicker({
        daysOfWeekDisabled: "1,5"
    });

    $('#date-range .input-daterange').datepicker({});

    $('#date-range-disable .input-daterange').datepicker({
        startDate: "03/17/2015",
        endDate: "03/25/2015"
    });
    
    // color plugin
    $('.color-default').colorpicker();
    
    $('.inputgrp').colorpicker();
                  
    // Horizontal mode
    $('#color-rgb').colorpicker({
        format: 'rgba', // force this format
        horizontal: true
    });
               
    
});