var GrooveIFrame = GrooveIFrame || {};

/*!
 * postMessage - v0.5 - 9/11/2009
 * http://benalman.com/
 * 
 * Copyright (c) 2009 "Cowboy" Ben Alman
 * Licensed under the MIT license
 * http://benalman.com/about/license/
 */

// Script: postMessage: Cross-domain scripting goodness
//
// *Version: 0.5, Last updated: 9/11/2009*
// 
// Project Home - http://benalman.com/projects/jquery-postmessage-plugin/
// GitHub       - http://github.com/cowboy/jquery-postmessage/
// Source       - http://github.com/cowboy/jquery-postmessage/raw/master/jquery.ba-postmessage.js
// (Minified)   - http://github.com/cowboy/jquery-postmessage/raw/master/jquery.ba-postmessage.min.js (0.9kb)
// 
// About: License
// 
// Copyright (c) 2009 "Cowboy" Ben Alman,
// Licensed under the MIT license.
// http://benalman.com/about/license/
// 
// About: Examples
// 
// This working example, complete with fully commented code, illustrates one
// way in which this plugin can be used.
// 
// Iframe resizing - http://benalman.com/code/projects/jquery-postmessage/examples/iframe/
// 
// About: Support and Testing
// 
// Information about what version or versions of jQuery this plugin has been
// tested with and what browsers it has been tested in.
// 
// jQuery Versions - 1.3.2
// Browsers Tested - Internet Explorer 6-8, Firefox 3, Safari 3-4, Chrome, Opera 9.
// 
// About: Release History
// 
// 0.5 - (9/11/2009) Improved cache-busting
// 0.4 - (8/25/2009) Initial release

(function($){
  '$:nomunge'; // Used by YUI compressor.

  // A few vars used in non-awesome browsers.
  var interval_id,
      last_hash,
      cache_bust = 1,

      // A var used in awesome browsers.
      rm_callback,

      // A few convenient shortcuts.
      window = this,
      FALSE = !1,

      // Reused internal strings.
      postMessage = 'postMessage',
      addEventListener = 'addEventListener',

      p_receiveMessage;

  var has_postMessage = window[postMessage];

  // Method: .postMessage
  // 
  // This method will call window.postMessage if available, setting the
  // targetOrigin parameter to the base of the target_url parameter for maximum
  // security in browsers that support it. If window.postMessage is not available,
  // the target window's location.hash will be used to pass the message. If an
  // object is passed as the message param, it will be serialized into a string
  // using the jQuery.param method.
  // 
  // Usage:
  // 
  // > .postMessage( message, target_url [, target ] );
  // 
  // Arguments:
  // 
  //  message - (String) A message to be passed to the other frame.
  //  message - (Object) An object to be serialized into a params string, using
  //    the jQuery.param method.
  //  target_url - (String) The URL of the other frame this window is
  //    attempting to communicate with. This must be the exact URL (including
  //    any query string) of the other window for this script to work in
  //    browsers that don't support window.postMessage.
  //  target - (Object) A reference to the other frame this window is
  //    attempting to communicate with. If omitted, defaults to `parent`.
  // 
  // Returns:
  // 
  //  Nothing.

  $[postMessage] = function( message, target_url, target ) {
    if ( !target_url ) { return; }

    // Serialize the message if not a string. Note that this is the only real
    // jQuery dependency for this script. If removed, this script could be
    // written as very basic JavaScript.
    message = typeof(message) === 'string' || 'undefined' === typeof($['param']) ? message : $.param( message );

    // Default to parent if unspecified.
    target = target || parent;

    if ( has_postMessage ) {
      // The browser supports window.postMessage, so call it with a targetOrigin
      // set appropriately, based on the target_url parameter.
      target.postMessage( message, target_url.replace( /([^:]+:\/\/[^\/]+).*/, '$1' ) );

    } else if ( target_url ) {
      // The browser does not support window.postMessage, so set the location
      // of the target to target_url#message. A bit ugly, but it works! A cache
      // bust parameter is added to ensure that repeat messages trigger the
      // callback.
      target.location = target_url.replace( /#.*$/, '' ) + '#' + (+new Date) + (cache_bust++) + '&' + message;
    }
  };

  
  // Method: .receiveMessage
  // 
  // Register a single callback for either a window.postMessage call, if
  // supported, or if unsupported, for any change in the current window
  // location.hash. If window.postMessage is supported and source_origin is
  // specified, the source window will be checked against this for maximum
  // security. If window.postMessage is unsupported, a polling loop will be
  // started to watch for changes to the location.hash.
  // 
  // Note that for simplicity's sake, only a single callback can be registered
  // at one time. Passing no params will unbind this event (or stop the polling
  // loop), and calling this method a second time with another callback will
  // unbind the event (or stop the polling loop) first, before binding the new
  // callback.
  // 
  // Also note that if window.postMessage is available, the optional
  // source_origin param will be used to test the event.origin property. From
  // the MDC window.postMessage docs: This string is the concatenation of the
  // protocol and "://", the host name if one exists, and ":" followed by a port
  // number if a port is present and differs from the default port for the given
  // protocol. Examples of typical origins are https://example.org (implying
  // port 443), http://example.net (implying port 80), and http://example.com:8080.
  // 
  // Usage:
  // 
  // > .receiveMessage( callback [, source_origin ] [, delay ] );
  // 
  // Arguments:
  // 
  //  callback - (Function) This callback will execute whenever a <.postMessage>
  //    message is received, provided the source_origin matches. If callback is
  //    omitted, any existing receiveMessage event bind or polling loop will be
  //    canceled.
  //  source_origin - (String) If window.postMessage is available and this value
  //    is not equal to the event.origin property, the callback will not be
  //    called.
  //  source_origin - (Function) If window.postMessage is available and this
  //    function returns false when passed the event.origin property, the
  //    callback will not be called.
  //  delay - (Number) An optional zero-or-greater delay in milliseconds at
  //    which the polling loop will execute (for browser that don't support
  //    window.postMessage). If omitted, defaults to 100.
  // 
  // Returns:
  // 
  //  Nothing!

  $['receiveMessage'] = p_receiveMessage = function( callback, source_origin, delay ) {
    if ( has_postMessage ) {
      // Since the browser supports window.postMessage, the callback will be
      // bound to the actual event associated with window.postMessage.

      if ( callback ) {
        // Unbind an existing callback if it exists.
        rm_callback && p_receiveMessage();

        // Bind the callback. A reference to the callback is stored for ease of
        // unbinding.
        rm_callback = function(e) {
          var so = 'string' === typeof(source_origin);

          var t = so && 'undefined' !== typeof(e);
          t = t && 'undefined' !== e['origin'];
          t = t && e['origin'] !== source_origin;
          
          var c = so && "[object Function]" === toString.call(source_origin);
          c = c && source_origin( e.origin ) === false;
          
          if ( t || c ) {
            return false;
          }
          callback( e );
        };
      }

      if ( window[addEventListener] ) {
        window[ callback ? addEventListener : 'removeEventListener' ]( 'message', rm_callback, FALSE );
      } else {
        window[ callback ? 'attachEvent' : 'detachEvent' ]( 'onmessage', rm_callback );
      }

    } else {

      interval_id && clearInterval( interval_id );
      interval_id = null;

      if ( callback ) {
        delay = typeof source_origin === 'number'
          ? source_origin
          : typeof delay === 'number'
            ? delay
            : 100;

        interval_id = setInterval(function(){
          var hash = document.location.hash,
            re = /^#?\d+&/;
          if ( hash !== last_hash && re.test( hash ) ) {
            last_hash = hash;
            callback({ data: hash.replace( re, '' ) });
          }
        }, delay );
      }
    }
  };

})(GrooveIFrame);
!function(window){

  // https://github.com/dperini/ContentLoaded
  function contentLoaded(fn) {
    var done = false, top = true,

    doc = window.document, root = doc.documentElement,

    add = doc.addEventListener ? 'addEventListener' : 'attachEvent',
    rem = doc.addEventListener ? 'removeEventListener' : 'detachEvent',
    pre = doc.addEventListener ? '' : 'on',

    init = function(e) {
      if (e.type == 'readystatechange' && doc.readyState != 'complete') return;
      (e.type == 'load' ? window : doc)[rem](pre + e.type, init, false);
      if (!done && (done = true)) fn.call(window, e.type || e);
    },

    poll = function() {
      try { root.doScroll('left'); } catch(e) { setTimeout(poll, 50); return; }
      init({type: 'poll'});
    };

    if (doc.readyState == 'complete') fn.call(window, 'lazy');
    else {
      if (doc.createEventObject && root.doScroll) {
        try { top = !window.frameElement; } catch(e) { }
        if (top) poll();
      }
      doc[add](pre + 'DOMContentLoaded', init, false);
      doc[add](pre + 'readystatechange', init, false);
      window[add](pre + 'load', init, false);
    }
  }

  window.GrooveWidget = {
    opened: false,
    online: false,
    _initialized: false,

    init: function(options) {
      this._initialized = true;
      this._options = options;

      // Setup the groove widget.
      contentLoaded(function(){ GrooveWidget.setup(); });
    },

    add: function() {
      if ( !this._initialized ) return false;

      this.remove();
      contentLoaded(function(){ GrooveWidget.setup(); });
    },

    remove: function() {
      if (!this.container.parentNode) return false;

      var oldContainer = this.container.parentNode.removeChild(this.container);
    },

    resetCustomStylesheet: function(refresh){
      if (!this._options.customization_stylesheet) return;

      var url = this._options.customization_stylesheet;

      // make sure we don't append cached version
      if (refresh)  url = url + '?_=' + ~~(Math.random() * 10000000);

      var stylesheet = this.addStylesheet(url);

      if (this.customStylesheet)
        this.customStylesheet.parentNode.removeChild(this.customStylesheet);

      this.customStylesheet = stylesheet;
    },

    setup: function() {
      // Setup stylesheets, including custom one.
      this.addStylesheet(this._options.stylesheet);
      this.resetCustomStylesheet();

      // Create groove widget wrapper.
      this.container = document.createElement('div');
      this.hide();
      this.container.id = 'groove-feedback';
      this.container.className = 'closed ' + this._options.position;
      this.container.innerHTML = this.createContainerMarkup();

      // Add created elements to page.
      document.body.appendChild(this.container);

      // Retrieve and store created child elements for later use.
      this.iframe = document.getElementById('groove-iframe');
      this.header = document.getElementById('gw-header');
      this.headerContent = document.getElementById('gw-header-content');
      this.backButton = document.getElementById('gw-back-button');
      this._postMessageIframe = window.frames['groove-iframe'];

      // Setup post message to observe for incoming messages.
      GrooveIFrame.receiveMessage(this.onMessage);
    },

    addStylesheet: function(url) {
      var stylesheet = document.createElement('link');
      stylesheet.rel = 'stylesheet';
      stylesheet.type = 'text/css';
      stylesheet.async = true;
      stylesheet.href = url;

      var container = document.getElementsByTagName('head')[0] || document;
      container.appendChild(stylesheet);

      return stylesheet;
    },

    createContainerMarkup: function() {
      this.url = this.buildIframeURL();

      return '<div id="groove-button">'
           + '  <a id="gw-back-button" href="#" onclick="GrooveWidget.backClicked(); return false;">Back</a>'
           + '  <a id="gw-header" href="#" onclick="GrooveWidget.toggle(); return false;"><span id="gw-header-content">'
           +      this._options.offlineHeaderText
           + '  </span></a>'
           + '</div>'
           + '<div class="iframe">'
           + '  <iframe id="groove-iframe" name="groove-iframe"'
           + '    allowTransparency="true"'
           + '    frameborder="0"'
           + '    scrolling="no"'
           + '    style = "min-height: ' + this._options.height + ';"'
           + '    src="' + this.url + '"'
           + '>'
           + '  </iframe>'
           + '</div>'
           + '<div id="gw-footer">'
           + '  <a href="http://www.groovehq.com" target="_blank">' + this._options.poweredByGrooveText + '</a>'
           + '</div>';
    },

    buildIframeURL: function() {
      var params = [
        'url=' + encodeURIComponent(window.location.href),
        'name=' + encodeURIComponent(this._options.enduser_name),
        'email=' + encodeURIComponent(this._options.enduser_email),
        'page_title=' + encodeURIComponent(document.title),
        'referrer=' + encodeURIComponent(document.referrer)
      ];

      return this._options.url + '?' + params.join('&');
    },

    onMessage: function(event) {
      var eventData;

      try {
        eventData = JSON.parse(event.data);
      } catch(e) {
        return; // probably received a message from other iframe
      }

      switch (eventData.name) {
        case 'close':
          GrooveWidget.setOpened(false); break;
        case 'open':
          GrooveWidget.setOpened(true); break;
        case 'ticket-offline':
          GrooveWidget.setOnline(false); break;
        case 'resize-height':
          GrooveWidget.setHeight(eventData.height); break;
        case 'set-state':
          GrooveWidget.setState(eventData.state); break;
        case 'widget-ready':
          if (typeof grooveOnLoad != 'undefined') {grooveOnLoad();}
          GrooveWidget.setupIOS();
          break;
        case 'set-panel':
          GrooveWidget.setPanel(eventData.panel); break;
        case 'show-back-button':
          GrooveWidget.showBackButton(eventData.show); break;
        case 'override-header-title':
          GrooveWidget.overrideHeaderTitle(eventData.title); break;
        case 'reset-header-title':
          GrooveWidget.resetHeaderTitle(); break;
        case 'set-zoom-level':
          GrooveWidget.setZoomLevel(); break;
      }
    },

    overrideHeaderTitle: function(title) {
      this.headerTitle = title;
      this.updateHeaderText();
    },

    resetHeaderTitle: function() {
      this.headerTitle = null;
      this.updateHeaderText();
    },

    setHeaderText: function(text){
      this.headerContent.innerHTML = text;

      // Only show container on first update of header text.
      if (!GrooveWidget._options.onlyShowOnline) {
        this.show();
      }
    },

    updateHeaderText: function() {
      // Update the groove widget's header based on online/opened states.
      if (this.headerTitle) {
        this.setHeaderText(this.headerTitle);
      } else if (this.opened && this.online) {
        this.setHeaderText(this._options.onlineHeaderTextOpen);
      } else if (this.opened) { // opened && offline
        this.setHeaderText(this._options.offlineHeaderTextOpen);
      } else if (this.online) { // closed && online
        this.setHeaderText(this._options.onlineHeaderText);
      } else {                  // closed && offline
        this.setHeaderText(this._options.offlineHeaderText);
      }
    },

    updateClassName: function() {
      this.container.className = (this.opened ? 'opened' : 'closed') + ' ' + this._options.position + ' ' + this.state + ' ' + (this.zoomLevel >= 0 ? ' zoom-level-' + this.zoomLevel : '');
    },

    setOpened: function(opened) {
      this.opened = opened;

      // Update header when opened state changes.
      this.updateHeaderText();
      this.updateClassName();
    },

    showBackButton: function(show) {
      this.backButton.className = show ? 'visible' : '';
    },

    setHeight: function(height) {
      this.iframe.setAttribute('height', height);
    },

    setState: function(state) {
      this.state = state;
      this.updateClassName();
    },

    setPanel: function(panel) {
      this.panel = panel;
      this.updateClassName();
    },

    setupIOS: function() {
      if( GrooveWidget.isIOSDevice() ) {
        document.addEventListener('gestureend', function(event) {
          setTimeout(GrooveWidget.setZoomLevel, 35);
        }, false);

        document.addEventListener('touchend', function(event) {
          setTimeout(GrooveWidget.setZoomLevel, 35);
        }, false);

        this.setZoomLevel();
      }
    },

    isIOSDevice: function() {
      return navigator.userAgent.match(/(iPhone);.*CPU.*OS [6,7,8]_\d/i);
    },

    calculateZoomLevel: function() {
      scale = document.documentElement.clientWidth / window.innerWidth;

      if(scale <= 1) {
        zoomLevel = 0;
      } else if (scale > 1 && scale <= 1.3) {
        zoomLevel = 1;
      } else if (scale > 1.3 && scale <= 1.75) {
        zoomLevel = 2;
      } else {
        zoomLevel = 3;
      }

      return zoomLevel;
    },

    setZoomLevel: function() {
      widget = GrooveWidget;
      widget.zoomLevel = widget.calculateZoomLevel();

      if(widget.previousZoomLevel == widget.zoomLevel) {
        return;
      }

      $container = $(widget.container)

      if (widget.previousZoomLevel >= 0) {
        $container.removeClass( 'zoom-level-' + widget.previousZoomLevel );
      }

      $container.addClass( 'zoom-level-' + widget.zoomLevel );
      widget.postIframeMessage('setZoomLevel', {  zoomLevel: widget.zoomLevel, previousZoomLevel: widget.previousZoomLevel });
      widget.previousZoomLevel = widget.zoomLevel;

      return $container;
    },

    open: function(options) {
      this.setOpened(true);
      this.postIframeMessage('widgetOpened');
      if (options && options.category)
        this.postIframeMessage('selectCategory', { category: options.category });
    },

    close: function() {
      this.setOpened(false);
      this.postIframeMessage('widgetClosed');
    },

    toggle: function() {
      if (this.opened) {
        this.close();
      } else {
        this.open()
      }
    },

    selectPanel: function(panel) {
      this.setOpened(true);
      this.postIframeMessage('selectPanel', { panel: panel });
    },

    backClicked: function() {
      this.postIframeMessage('backClicked');
    },

    options: function(apiOptions) {
      this.postIframeMessage('apiOptions', { apiOptions: apiOptions });
      return this.apiOptions;
    },

    hide: function(){
      this.container.style.display = 'none';
    },

    show: function(){
      this.container.style.display = 'block';
    },

    postIframeMessage: function(name, payload){
      if (!payload) payload = {};
      payload.name = name;
      GrooveIFrame.postMessage(JSON.stringify(payload), this.url, this._postMessageIframe);
    }
  };
}(window);

GrooveWidget.init({"position":"right","onlineHeaderText":"Click here for help","onlineHeaderTextOpen":"Click here for help","offlineHeaderText":"Click here for help","offlineHeaderTextOpen":"Click here for help","chattingWith":"Chatting with","url":"https://automaticviral.groovehq.com/widgets/b35735f2-1583-4c0c-9ad7-66b6821a7def/ticket/init","stylesheet":"http://automaticviral.groovehq.com/assets/groove.widget-e74321d1780c45644500b8064f0e7101.css","customization_stylesheet":null,"height":"70px","origin":"http://automaticviral.groovehq.com","enduser_name":"","enduser_email":"","onlyShowOnline":false,"poweredByGrooveText":"Powered by Groove","chatOnly":false});

