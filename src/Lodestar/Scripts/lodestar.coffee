class InfoModel extends Backbone.Model


class InfoCollection extends Backbone.Collection
    model: InfoModel


class InfoView extends Backbone.View
    template: _.template($("#tpl-info").html())
    render: (eventName) ->
        $(@.el).html(@.template({ items: @.model.toJSON()}))
        @


window.lodestar = {} unless window.lodestar
window.lodestar.InfoModel = InfoModel
window.lodestar.InfoCollection = InfoCollection
window.lodestar.InfoView = InfoView
