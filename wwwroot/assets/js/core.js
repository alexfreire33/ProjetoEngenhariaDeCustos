'use strict';

jQuery(document).ready(function () {

    // leftbar toggle for minbar
    var nice = jQuery(".left-bar").niceScroll(); 
    jQuery('.menu-bar').click(function(){                  
        jQuery(".wrapper").toggleClass('mini-bar');        

        jQuery(".left-bar").getNiceScroll().remove();
        setTimeout(function() {
            jQuery(".left-bar").niceScroll();
        }, 200);
    }); 
    
    // mobile menu
    jQuery('.menu-bar-mobile').on('click', function (e) {        
        // jQuery(this).addClass('menu_appear');
        jQuery(".left-bar").getNiceScroll().remove();
        
        jQuery( ".left-bar" ).toggleClass("menu_appear" );
        jQuery( ".overlay" ).toggleClass("show" );
        setTimeout(function() {
          jQuery(".left-bar").niceScroll();
        }, 200);
    });

    // orvelay hide menu
    jQuery(".overlay").on('click',function(){
        jQuery( ".left-bar" ).toggleClass("menu_appear" );
        jQuery(this).removeClass("show");
    });

    // right side-bar toggle
    jQuery('.right-bar-toggle').on('click', function(e){
        e.preventDefault();
        jQuery('.wrapper').toggleClass('right-bar-enabled');
    });

    jQuery('ul.menu-parent').accordion();

    new WOW().init(); 

    // PANELS
    // panel close
    jQuery('.panel-close').on('click', function (e) {
        e.preventDefault();
        jQuery(this).parent().parent().parent().parent().addClass(' animated fadeOutDown');
    });


    jQuery('.panel-minimize').on('click', function (e) 
    {
        e.preventDefault();
        var jQuerytarget = jQuery(this).parent().parent().parent().next('.panel-body');
        if (jQuerytarget.is(':visible')) {
            jQuery('i', jQuery(this)).removeClass('ti-angle-up').addClass('ti-angle-down');
        } else {
            jQuery('i', jQuery(this)).removeClass('ti-angle-down').addClass('ti-angle-up');
        }
        jQuerytarget.slideToggle();
    });
    
    
    jQuery('.panel-refresh').on('click', function (e) 
    {
        e.preventDefault();
        // alert('vj');
        var jQuerytarget = jQuery(this).closest('.panel-heading').next('.panel-body');
        jQuerytarget.mask('<i class="fa fa-refresh fa-spin"></i> Loading...');

        setTimeout(function () {
            jQuerytarget.unmask();
            console.log('ended');
        },1000);
    });

    //Active menu item expand automatically on reload or fresh open
    
    if (!jQuery('.wrapper').hasClass("mini-bar") && jQuery(window).width() > 1200) {
        jQuery('.submenu li.active').closest('.submenu').addClass('current');
        var activeMenu = jQuery('.submenu li.current').closest('ul').css('display','block');
    }
    


    if(jQuery(".mail_list").length > 0){
        jQuery(".mail_list").niceScroll();    
    }

    if(jQuery(".mails_holder").length > 0){
        jQuery(".mails_holder").niceScroll();    
    }

    if(jQuery(".mail_brief_holder").length > 0){
        jQuery(".mail_brief_holder").niceScroll();    
    }
    
    if(jQuery("#paginator").length > 0){
        jQuery('#paginator').datepaginator();
    }

    if(jQuery(".table-row").length > 0){
        jQuery('.table-row').on('click', function(){
            // jQuery('.table-row').removeClass('active');
            jQuery(this).toggleClass('active');
        }); 
    }

    if(jQuery(".pick-a-color").length > 0){
        jQuery(".pick-a-color").pickAColor({
          showSpectrum            : true,
            showSavedColors         : true,
            saveColorsPerElement    : true,
            fadeMenuToggle          : true,
            showAdvanced            : true,
            showBasicColors         : true,
            showHexInput            : true,
            allowBlank              : true,
            inlineDropdown          : true
        });    
    }

    if(jQuery('#colorPicker').length > 0){
        var jQuerybox = jQuery('#colorPicker');
        jQuerybox.tinycolorpicker();    
    }

    if(jQuery('#picker').length > 0){
        jQuery('#picker').colpick({
            flat:true,
            layout:'hex',
            submit:0
        });    
    }

    var endDate = "June 7, 2087 15:03:25";
    if(jQuery('.countdown.styled').length > 0){
        jQuery('.countdown.styled').countdown({
            date: endDate,
            render: function(data) {
                jQuery(this.el).html("<div>" + this.leadingZeros(data.years, 2) + " <span>years</span></div><div>" + this.leadingZeros(data.days, 2) + " <span>days</span></div><div>" + this.leadingZeros(data.hours, 2) + " <span>hrs</span></div><div>" + this.leadingZeros(data.min, 2) + " <span>min</span></div><div>" + this.leadingZeros(data.sec, 2) + " <span>sec</span></div>");
            }
        });    
    }

    if(jQuery(".openNav").length > 0){
        jQuery(".openNav").click(function() {
            jQuery(this).toggleClass("open");
        });
    }
    
    if(jQuery("#elm1").length > 0){
        tinymce.init({
            selector: "textarea#elm1",
            theme: "modern",
            height:300,
            plugins: [
                "advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
                "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                "save table contextmenu directionality emoticons template paste textcolor"
            ],
            toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons", 
            style_formats: [
                {title: 'Bold text', inline: 'b'},
                {title: 'Red text', inline: 'span', styles: {color: '#ff0000'}},
                {title: 'Red header', block: 'h1', styles: {color: '#ff0000'}},
                {title: 'Example 1', inline: 'span', classes: 'example1'},
                {title: 'Example 2', inline: 'span', classes: 'example2'},
                {title: 'Table styles'},
                {title: 'Table row 1', selector: 'tr', classes: 'tablerow1'}
            ]
        });    
    }  
});