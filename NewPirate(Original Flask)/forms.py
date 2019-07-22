# forms.py

from wtforms import Form, StringField, SelectField, validators

class ShipForm(Form):
    choices = [('Ship', 'Ship'),
               ('Pirate', 'Pirate'),
               ('Port', 'Port')]
    select = SelectField('Search for Pirate:', choices=choices)
    search = StringField('')


class PirateForm(Form):
    good_or_evil = [('Good', 'Good'),
                   ('Evil', 'Evil'),
                   ('Depends', 'Depends')
                   ]
    name = StringField('Names')   
    ship = StringField('Ship')
    port = StringField('Port')
    good_or_evil = SelectField('Side', choices=good_or_evil)
