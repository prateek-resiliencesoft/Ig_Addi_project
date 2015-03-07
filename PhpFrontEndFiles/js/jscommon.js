var Common;

Common = {};

Common.loadModal = function(url) {
  return $.get(url, (function(_this) {
    return function(data) {
      var close;
      close = function() {
        $('#modal-container').html('');
        $('#overlay').hide();
        return $('html').off('keydown');
      };
      $('#modal-container').html(data).fadeIn(100);
      $('#modal-container .modal').prepend('<div class="closer"></div>');
      $('#overlay').fadeIn(100);
      $('html').on({
        click: function(e) {
          return close();
        }
      }, '.modal .closer');
      return $('html').on({
        keydown: function(e) {
          if (e.keyCode === 27) {
            return close();
          }
        }
      });
    };
  })(this));
};

Common.coverBlockWithOverlay = function($overlay, jqObjects, callback) {
  var $jqObj, height, _i, _len;
  $overlay.css('width', jqObjects[0].outerWidth());
  height = 0;
  for (_i = 0, _len = jqObjects.length; _i < _len; _i++) {
    $jqObj = jqObjects[_i];
    height += $jqObj.outerHeight();
  }
  $overlay.css('height', height);
  return $overlay.fadeIn(200, function() {
    if (callback != null) {
      return callback();
    }
  });
};

Common.disableFormInputs = function($form) {
  $form.find('input').prop('disabled', true);
  return $form.find('.icon-input').addClass('disabled');
};

Common.enableFormInputs = function($form) {
  $form.find('input').prop('disabled', false);
  return $form.find('.icon-input').removeClass('disabled');
};

$(function() {
  $('#subscr-plan-dropdown').on({
    click: function(e) {
      var $target, packetId, text;
      $target = $(e.currentTarget);
      packetId = $target.data().packetId;
      text = $target.find('a').text();
      $('.dropdown-btn.choose-plan').text(text).addClass('changed');
      return $('input[name="sub"]').val(packetId);
    }
  }, '.dropdown-menu li');
  $('#add-credits-dropdown').on({
    click: function(e) {
      var $target, credits, text;
      $target = $(e.currentTarget);
      credits = $target.data().credits;
      text = $target.find('a').text();
      $('.dropdown-btn.add-credits').text(text).addClass('changed');
      return $('input[name="package"]').val(credits);
    }
  }, '.dropdown-menu li');
  return $('#settings-billing-info').on({
    click: function(e) {
      var close;
      e.preventDefault();
      Common.loadModal('/modal/billing-info-form');
      close = function() {
        $('#modal-container').html('');
        $('#overlay').hide();
        return $('html').off('keydown');
      };
      $('html').on({
        keydown: function(e) {
          if (e.keyCode === 27) {
            return close();
          }
        }
      });
      return $('html').on({
        click: function(e) {
          return close();
        }
      }, '.modal .closer');
    }
  }, '.load-billing-info-form');
});

$(function() {
  var handleInputFocus, setDropdownInactive;

    $('html').on({
        click: function(e) {
            e.stopPropagation();
            return true;
        }
    }, 'form div.checkbox-group a');
  $('html').on({
    click: function(e) {
      var $checkboxInput, $target;
      $target = $(e.currentTarget);
      $checkboxInput = $target.find('input[type="checkbox"]').first();
      if ($checkboxInput.is(':checked')) {
        $checkboxInput.prop('checked', false);
        return $target.removeClass('checked');
      } else {
        $checkboxInput.prop('checked', true);
        return $target.addClass('checked');
      }
    }
  }, 'form div.checkbox-group');
  handleInputFocus = function(e) {
    var $ico;
    $ico = $(e.currentTarget).parents('.icon-input').first().find('.icon div');
    if (e.type === 'focusin') {
      return $ico.addClass('hov');
    } else if (e.type === 'focusout') {
      return $ico.removeClass('hov');
    }
  };
  $('html').on({
    focusin: handleInputFocus,
    focusout: handleInputFocus
  }, '.icon-input input');
  setDropdownInactive = function() {
    var $dd;
    $dd = $('#topbar .menu li.my-account');
    $dd.removeClass('active');
    return clearTimeout($dd.data('timeout'));
  };
  $('html').on({
        click: function(e) {
            e.stopPropagation();
            return true;
        }
    }, '#topbar .menu li.my-account .text');
  $('html').on({
    click: function(e) {
      var $target;
      if (!$(e.target).is('a')) {
        $target = $(e.currentTarget);
        return $target.addClass('active');
      }
    }
  }, '#topbar .menu li.my-account');
  $('html').on({
    'mouseleave.dd': function(e) {
      return $('#topbar .menu li.my-account').data('timeout', setTimeout(setDropdownInactive, 300));
    }
  }, '#topbar .menu li.my-account');
  return $('html').on({
    'mouseenter.dd': function(e) {
      return clearTimeout($(e.currentTarget).data('timeout'));
    }
  }, '#topbar .menu li.my-account');

});

