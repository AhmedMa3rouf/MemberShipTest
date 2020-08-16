var THEMEMASCOT = {};

(function($) {
    "use strict";

    /* ---------------------------------------------------------------------- */
    /* -------------------------- Declare Variables ------------------------- */
    /* ---------------------------------------------------------------------- */
    var $document = $(document);
    var $document_body = $(document.body);
    var $window = $(window);
    var $html = $('html');
    var $body = $('body');
    var $wrapper = $('#wrapper');
    var $header = $('#header');
    var $footer = $('#footer');
    var $sections = $('section');
    var $portfolio_gallery = $(".gallery-isotope");
    var portfolio_filter = ".portfolio-filter a";
    var $portfolio_filter_first_child = $(".portfolio-filter a:eq(0)");
    var $portfolio_flex_slider = $(".portfolio-slider");


    THEMEMASCOT.isMobile = {
        Android: function() {
            return navigator.userAgent.match(/Android/i);
        },
        BlackBerry: function() {
            return navigator.userAgent.match(/BlackBerry/i);
        },
        iOS: function() {
            return navigator.userAgent.match(/iPhone|iPad|iPod/i);
        },
        Opera: function() {
            return navigator.userAgent.match(/Opera Mini/i);
        },
        Windows: function() {
            return navigator.userAgent.match(/IEMobile/i);
        },
        any: function() {
            return (THEMEMASCOT.isMobile.Android() || THEMEMASCOT.isMobile.BlackBerry() || THEMEMASCOT.isMobile.iOS() || THEMEMASCOT.isMobile.Opera() || THEMEMASCOT.isMobile.Windows());
        }
    };

    THEMEMASCOT.isRTL = {
        check: function() {
            if( $( "html" ).attr("dir") == "rtl" ) {
                return true;
            } else {
                return false;
            }
        }
    };




    THEMEMASCOT.initialize = {

        init: function() {
            THEMEMASCOT.initialize.TM_loadBSParentModal();
            THEMEMASCOT.initialize.TM_platformDetect();
            THEMEMASCOT.initialize.TM_customDataAttributes();
            THEMEMASCOT.initialize.TM_parallaxBgInit();
            THEMEMASCOT.initialize.TM_resizeFullscreen();
            THEMEMASCOT.initialize.TM_fitVids();
            THEMEMASCOT.initialize.TM_YTPlayer();
            THEMEMASCOT.initialize.TM_equalHeightDivs();
        },



        /* ---------------------------------------------------------------------- */
        /* ------------------------ Bootstrap Parent Modal  --------------------- */
        /* ---------------------------------------------------------------------- */
        TM_loadBSParentModal: function() {
            var ajaxLoadContent = false;
            if( ajaxLoadContent ) {
                $.ajax({
                    url: "ajax-load/bootstrap-parent-modal.html",
                    success: function (data) { $body.append(data); },
                    dataType: 'html'
                });
            }
        },


        /* ---------------------------------------------------------------------- */
        /* ------------------------------ Preloader  ---------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_preLoaderClickDisable: function() {
            var $preloader = $('#preloader');
            $preloader.children('#disable-preloader').on('click', function(e) {
                $preloader.fadeOut();
                return false;
            });
        },

        TM_preLoaderOnLoad: function() {
            var $preloader = $('#preloader');
            if( $preloader.length > 0 ) {
                $preloader.delay(200).fadeOut('slow');
            }
        },


        /* ---------------------------------------------------------------------- */
        /* ------------------------------- Platform detect  --------------------- */
        /* ---------------------------------------------------------------------- */
        TM_platformDetect: function() {
            if (THEMEMASCOT.isMobile.any()) {
                $html.addClass("mobile");
            } else {
                $html.addClass("no-mobile");
            }
        },


        /* ---------------------------------------------------------------------- */
        /* ------------------------------ Hash Forwarding  ---------------------- */
        /* ---------------------------------------------------------------------- */
        TM_hashForwarding: function() {
            if (window.location.hash) {
                var hash_offset = $(window.location.hash).offset().top;
                $("html, body").animate({
                    scrollTop: hash_offset
                });
            }
        },


        /* ---------------------------------------------------------------------- */
        /* ----------------------- Background image, color ---------------------- */
        /* ---------------------------------------------------------------------- */
        TM_customDataAttributes: function() {
            $('[data-bg-color]').each(function() {
                $(this).css("cssText", "background: " + $(this).data("bg-color") + " !important;");
            });
            $('[data-bg-img]').each(function() {
                $(this).css('background-image', 'url(' + $(this).data("bg-img") + ')');
            });
            $('[data-text-color]').each(function() {
                $(this).css('color', $(this).data("text-color"));
            });
            $('[data-font-size]').each(function() {
                $(this).css('font-size', $(this).data("font-size"));
            });
            $('[data-height]').each(function() {
                $(this).css('height', $(this).data("height"));
            });
            $('[data-border]').each(function() {
                $(this).css('border', $(this).data("border"));
            });
            $('[data-margin-top]').each(function() {
                $(this).css('margin-top', $(this).data("margin-top"));
            });
            $('[data-margin-right]').each(function() {
                $(this).css('margin-right', $(this).data("margin-right"));
            });
            $('[data-margin-bottom]').each(function() {
                $(this).css('margin-bottom', $(this).data("margin-bottom"));
            });
            $('[data-margin-left]').each(function() {
                $(this).css('margin-left', $(this).data("margin-left"));
            });
        },



        /* ---------------------------------------------------------------------- */
        /* -------------------------- Background Parallax ----------------------- */
        /* ---------------------------------------------------------------------- */
        TM_parallaxBgInit: function() {
            if (!THEMEMASCOT.isMobile.any() && $window.width() >= 800 ) {
                $('.parallax').each(function() {
                    var data_parallax_ratio = ( $(this).data("parallax-ratio") === undefined ) ? '0.5': $(this).data("parallax-ratio");
                    $(this).parallax("50%", data_parallax_ratio);
                });
            } else {
                $('.parallax').addClass("mobile-parallax");
            }
        },

        /* ---------------------------------------------------------------------- */
        /* --------------------------- Home Resize Fullscreen ------------------- */
        /* ---------------------------------------------------------------------- */
        TM_resizeFullscreen: function() {
            var windowHeight = $window.height();
            $('.fullscreen, .revslider-fullscreen').height(windowHeight);
        },



        /* ---------------------------------------------------------------------- */
        /* ---------------------------- Wow initialize  ------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_wow: function() {
            var wow = new WOW({
                mobile: false // trigger animations on mobile devices (default is true)
            });
            wow.init();
        },

        /* ---------------------------------------------------------------------- */
        /* ----------------------------- Fit Vids ------------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_fitVids: function() {
            $body.fitVids();
        },

        /* ---------------------------------------------------------------------- */
        /* ----------------------------- YT Player for Video -------------------- */
        /* ---------------------------------------------------------------------- */
        TM_YTPlayer: function() {
            var $ytube_player = $(".player");
            if( $ytube_player.length > 0 ) {
                $ytube_player.mb_YTPlayer();
            }
        },

        /* ---------------------------------------------------------------------- */
        /* ---------------------------- equalHeights ---------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_equalHeightDivs: function() {
            /* equal heigh */
            var $equal_height = $('.equal-height');
            if( $equal_height.length > 0 ) {
                $equal_height.children('div').css('min-height', 'auto');
                $equal_height.equalHeights();
            }

            /* equal heigh inner div */
            var $equal_height_inner = $('.equal-height-inner');
            if( $equal_height_inner.length > 0 ) {
                $equal_height_inner.children('div').css('min-height', 'auto');
                $equal_height_inner.children('div').children('div').css('min-height', 'auto');
                $equal_height_inner.equalHeights();
                $equal_height_inner.children('div').each(function() {
                    $(this).children('div').css('min-height', $(this).css('min-height'));
                });
            }
        }

    };


    THEMEMASCOT.header = {

        init: function() {

            var t = setTimeout(function() {
                THEMEMASCOT.header.TM_fullscreenMenu();
                THEMEMASCOT.header.TM_sidePanelReveal();
                THEMEMASCOT.header.TM_scroolToTopOnClick();
                THEMEMASCOT.header.TM_scrollToFixed();
                THEMEMASCOT.header.TM_topnavAnimate();
                THEMEMASCOT.header.TM_menuzord();
                THEMEMASCOT.header.TM_navLocalScorll();
                THEMEMASCOT.header.TM_menuCollapseOnClick();
                THEMEMASCOT.header.TM_homeParallaxFadeEffect();
                THEMEMASCOT.header.TM_topsearch_toggle();
            }, 0);

        },


        /* ---------------------------------------------------------------------- */
        /* ------------------------- menufullpage ---------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_fullscreenMenu: function() {
            var $menufullpage = $('.menu-full-page .fullpage-nav-toggle');
            if( $menufullpage.length > 0 ) {
                $menufullpage.menufullpage();
            }
        },


        /* ---------------------------------------------------------------------- */
        /* ------------------------- Side Push Panel ---------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_sidePanelReveal: function() {
            $('.side-panel-trigger').on('click', function(e) {
                $body.toggleClass("side-panel-open");
                if ( THEMEMASCOT.isMobile.any() ) {
                    $body.toggleClass("overflow-hidden");
                }
                return false;
            });

            $('.has-side-panel .body-overlay').on('click', function(e) {
                $body.toggleClass("side-panel-open");
                return false;
            });

            //sitebar tree
            $('.side-panel-nav .nav .tree-toggler').on('click', function(e) {
                $(this).parent().children('ul.tree').toggle(300);
            });
        },

        /* ---------------------------------------------------------------------- */
        /* ------------------------------- scrollToTop  ------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_scroolToTop: function() {
            if ($window.scrollTop() > 600) {
                $('.scrollToTop').fadeIn();
            } else {
                $('.scrollToTop').fadeOut();
            }
        },

        TM_scroolToTopOnClick: function() {
            $document_body.on('click', '.scrollToTop', function(e) {
                $('html, body').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        },


        /* ---------------------------------------------------------------------------- */
        /* --------------------------- One Page Nav close on click -------------------- */
        /* ---------------------------------------------------------------------------- */
        TM_menuCollapseOnClick: function() {
            $document.on('click', '.onepage-nav a', function(e) {
                $('.showhide').trigger('click');
                return false;
            });
        },
        
                /* ---------------------------------------------------------------------- */
        /* ----------- Active Menu Item on Reaching Different Sections ---------- */
        /* ---------------------------------------------------------------------- */
        TM_activateMenuItemOnReach: function() {
            var $onepage_nav = $('.onepage-nav');
            var cur_pos = $window.scrollTop() + 2;
            var nav_height = $onepage_nav.outerHeight();
            $sections.each(function() {
                var top = $(this).offset().top - nav_height - 80,
                    bottom = top + $(this).outerHeight();

                if (cur_pos >= top && cur_pos <= bottom) {
                    $onepage_nav.find('a').parent().removeClass('current').removeClass('active');
                    $sections.removeClass('current').removeClass('active');

                    //$(this).addClass('current').addClass('active');
                    $onepage_nav.find('a[href="#' + $(this).attr('id') + '"]').parent().addClass('current').addClass('active');
                }
            });
        },
        /* ---------------------------------------------------------------------- */
        /* ------------------- on click scrool to target with smoothness -------- */
        /* ---------------------------------------------------------------------- */
        TM_scrolltoTarget: function() {
            //jQuery for page scrolling feature - requires jQuery Easing plugin
            $('.smooth-scroll-to-target, .fullscreen-onepage-nav a').on('click', function(e) {
                e.preventDefault();

                var $anchor = $(this);
                
                var $hearder_top = $('.header .header-nav');
                var hearder_top_offset = 0;
                if ($hearder_top[0]){
                    hearder_top_offset = $hearder_top.outerHeight(true);
                } else {
                    hearder_top_offset = 0;
                }

                //for vertical nav, offset 0
                if ($body.hasClass("vertical-nav")){
                    hearder_top_offset = 0;
                }

                var top = $($anchor.attr('href')).offset().top - hearder_top_offset;
                $('html, body').stop().animate({
                    scrollTop: top
                }, 1500, 'easeInOutExpo');

            });
        },
        /* ---------------------------------------------------------------------------- */
        /* --------------------------- collapsed menu close on click ------------------ */
        /* ---------------------------------------------------------------------------- */
        TM_scrollToFixed: function() {
            $('.navbar-scrolltofixed').scrollToFixed();
            $('.scrolltofixed').scrollToFixed({
                marginTop: $('.header .header-nav').outerHeight(true) + 10,
                limit: function() {
                    var limit = $('#footer').offset().top - $(this).outerHeight(true);
                    return limit;
                }
            });
            $('#sidebar').scrollToFixed({
                marginTop: $('.header .header-nav').outerHeight() + 0,
                limit: function() {
                    var limit = $('#footer').offset().top - $('#sidebar').outerHeight() - 0;
                    return limit;
                }
            });
        },
        
        /* ---------------------------------------------------------------------- */
        /* -------------------------- Scroll navigation ------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_navLocalScorll: function() {
            var data_offset = -60;
            var $local_scroll = $("#menuzord .menuzord-menu, #menuzord-right .menuzord-menu");
            if( $local_scroll.length > 0 ) {
                $local_scroll.localScroll({
                    target: "body",
                    duration: 800,
                    offset: data_offset,
                    easing: "easeInOutExpo"
                });
            }

            var $local_scroll_other = $("#menuzord-side-panel .menuzord-menu, #menuzord-verticalnav .menuzord-menu, #fullpage-nav");
            if( $local_scroll_other.length > 0 ) {
                $local_scroll_other.localScroll({
                    target: "body",
                    duration: 800,
                    offset: 0,
                    easing: "easeInOutExpo"
                });
            }
        },
        

        /* ----------------------------------------------------------------------------- */
        /* --------------------------- Menuzord - Responsive Megamenu ------------------ */
        /* ----------------------------------------------------------------------------- */
        TM_menuzord: function() {

            var $menuzord = $("#menuzord");
            if( $menuzord.length > 0 ) {
                $menuzord.menuzord({
                    align: "left",
                    effect: "slide",
                    animation: "none",
                    indicatorFirstLevel: "<i class='fa fa-angle-down'></i>",// fa-angle-down
                    indicatorSecondLevel: "<i class='fa fa-angle-left'></i>"
                });
            }

            var $menuzord_right = $("#menuzord-right");
            if( $menuzord_right.length > 0 ) {
                $menuzord_right.menuzord({
                    align: "right",
                    effect: "slide",
                    animation: "none",
                    indicatorFirstLevel: "<i class='fa fa-angle-down'></i>", //fa-angle-down
                    indicatorSecondLevel: "<i class='fa fa-angle-left'></i>"
                });
            }

            var $menuzord_side_panel = $("#menuzord-side-panel");
            if( $menuzord_side_panel.length > 0 ) {
                $menuzord_side_panel.menuzord({
                    align: "right",
                    effect: "slide",
                    animation: "none",
                    indicatorFirstLevel: "",
                    indicatorSecondLevel: "<i class='fa fa-angle-left'></i>"
                });
            }
            
            var $menuzord_vertical_nav = $("#menuzord-verticalnav");
            if( $menuzord_vertical_nav.length > 0 ) {
                $menuzord_vertical_nav.menuzord({
                    align: "right",
                    effect: "slide",
                    animation: "none",
                    indicatorFirstLevel: "<i class='fa fa-angle-down'></i>",// fa-angle-down
                    indicatorSecondLevel: "<i class='fa fa-angle-left'></i>"
                });
            }

        },

        /* ---------------------------------------------------------------------- */
        /* --------------------------- Waypoint Top Nav Sticky ------------------ */
        /* ---------------------------------------------------------------------- */
        TM_topnavAnimate: function() {
            if ($window.scrollTop() > (50)) {
                $(".navbar-sticky-animated").removeClass("animated-active");
                //$("#NavHeaderimg").attr("src", "images/Sadeed1.png");
            } else {
                $(".navbar-sticky-animated").addClass("animated-active");
                //$("#NavHeaderimg").attr("src", "images/Sadeed1.png");
            }

            if ($window.scrollTop() > (50)) {
                $(".navbar-sticky-animated .header-nav-wrapper .container, .navbar-sticky-animated .header-nav-wrapper .container-fluid").removeClass("add-padding");
            } else {
                $(".navbar-sticky-animated .header-nav-wrapper .container, .navbar-sticky-animated .header-nav-wrapper .container-fluid").addClass("add-padding");
            }
        },

        /* ---------------------------------------------------------------------- */
        /* ---------------- home section on scroll parallax & fade -------------- */
        /* ---------------------------------------------------------------------- */
        TM_homeParallaxFadeEffect: function() {
            if ($window.width() >= 1200) {
                var scrolled = $window.scrollTop();
                $('.content-fade-effect .home-content .home-text').css('padding-top', (scrolled * 0.0610) + '%').css('opacity', 1 - (scrolled * 0.00120));
            }
        },



    };

    THEMEMASCOT.widget = {

        init: function() {

            var t = setTimeout(function() {
                THEMEMASCOT.widget.TM_accordion_toggles();
                THEMEMASCOT.widget.TM_tooltip();
                //THEMEMASCOT.widget.TM_countDownTimer();
            }, 0);

        },

        /* ---------------------------------------------------------------------- */
        /* ------------------------- accordion & toggles ------------------------ */
        /* ---------------------------------------------------------------------- */
        TM_accordion_toggles: function() {
            var $panel_group_collapse = $('.panel-group .collapse');
            $panel_group_collapse.on("show.bs.collapse", function(e) {
                $(this).closest(".panel-group").find("[href='#" + $(this).attr("id") + "']").addClass("active");
            });
            $panel_group_collapse.on("hide.bs.collapse", function(e) {
                $(this).closest(".panel-group").find("[href='#" + $(this).attr("id") + "']").removeClass("active");
            });
        },

        /* ---------------------------------------------------------------------- */
        /* ------------------------------- tooltip  ----------------------------- */
        /* ---------------------------------------------------------------------- */
        TM_tooltip: function() {
            var $tooltip = $('[data-toggle="tooltip"]');
            if( $tooltip.length > 0 ) {
                $tooltip.tooltip();
            }
        },
    };

    THEMEMASCOT.slider = {

        init: function() {

            var t = setTimeout(function() {
                THEMEMASCOT.slider.TM_maximageSlider();
            }, 0);

        },



        /* ---------------------------------------------------------------------- */
        /* ---------- maximage Fullscreen Parallax Background Slider  ----------- */
        /* ---------------------------------------------------------------------- */
        TM_maximageSlider: function() {
            var $maximage_slider = $('#maximage');
            if( $maximage_slider.length > 0 ) {
                $maximage_slider.maximage({
                    cycleOptions: {
                        fx: 'fade',
                        speed: 1500,
                        prev: '.img-prev',
                        next: '.img-next'
                    }
                });
            }
        }
    };


    /* ---------------------------------------------------------------------- */
    /* ---------- document ready, window load, scroll and resize ------------ */
    /* ---------------------------------------------------------------------- */
    //document ready
    THEMEMASCOT.documentOnReady = {
        init: function() {
            THEMEMASCOT.initialize.init();
            THEMEMASCOT.header.init();
            THEMEMASCOT.slider.init();
            THEMEMASCOT.widget.init();
            THEMEMASCOT.windowOnscroll.init();
        }
    };

    //window on load
    THEMEMASCOT.windowOnLoad = {
        init: function() {
            var t = setTimeout(function() {
                THEMEMASCOT.initialize.TM_wow();
                THEMEMASCOT.initialize.TM_preLoaderOnLoad();
                THEMEMASCOT.initialize.TM_hashForwarding();
                THEMEMASCOT.initialize.TM_parallaxBgInit();
            }, 0);
            $window.trigger("scroll");
            $window.trigger("resize");
        }
    };

    //window on scroll
    THEMEMASCOT.windowOnscroll = {
        init: function() {
            $window.on( 'scroll', function(){
                THEMEMASCOT.header.TM_scroolToTop();
                THEMEMASCOT.header.TM_activateMenuItemOnReach();
                THEMEMASCOT.header.TM_topnavAnimate();
            });
        }
    };

    //window on resize
    THEMEMASCOT.windowOnResize = {
        init: function() {
            var t = setTimeout(function() {
                THEMEMASCOT.initialize.TM_equalHeightDivs();
                THEMEMASCOT.initialize.TM_resizeFullscreen();
            }, 400);
        }
    };


    /* ---------------------------------------------------------------------- */
    /* ---------------------------- Call Functions -------------------------- */
    /* ---------------------------------------------------------------------- */
    $document.ready(
        THEMEMASCOT.documentOnReady.init
    );
    $window.on('load',
        THEMEMASCOT.windowOnLoad.init
    );
    $window.on('resize', 
        THEMEMASCOT.windowOnResize.init
    );

    //call function before document ready
    THEMEMASCOT.initialize.TM_preLoaderClickDisable();
//
      
})(jQuery);