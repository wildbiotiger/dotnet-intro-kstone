# forms.py

from wtforms import Form, StringField, SelectField, validators
from wtforms.validators import DataRequired

class ShipForm(Form):
    choices = [('Pirate', 'Pirate'),
               ('Ship', 'Ship'),
               ('Port', 'Port')]
    select = SelectField('Search for Pirate:', choices=choices)
    search = StringField('')
    
class PirateForm(Form):
    good_or_evil = [('Good', 'Good'),
                   ('Evil', 'Evil'),
                   ('Depends', 'Depends')]
    name = StringField('Name', [DataRequired(message=('Please enter in Pirate Name'))])   
    ship = StringField('Ship', [DataRequired(message=('Please enter in Ship Name'))])
    port = StringField('Port', [DataRequired(message=('Please enter in Port Name'))])
    good_or_evil = SelectField('Side', choices=good_or_evil)
    
class DeletePirateForm(Form):
	name = StringField('Name', render_kw ={'readonly':True})
