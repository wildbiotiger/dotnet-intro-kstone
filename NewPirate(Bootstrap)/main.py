# main.py

from app import app
from db_setup import db_session
from forms import PirateForm, ShipForm, DeletePirateForm
from flask import flash, render_template, request, redirect
from models import Ship, Pirate, Port
from tables import Results
from flask_bootstrap import Bootstrap

@app.route('/', methods=['GET', 'POST'])
def index():
    search = ShipForm(request.form)
    if request.method == 'POST':
        return search_results(search)

    return render_template('index.html', form=search)

@app.route('/results')
def search_results(search):
    results = []
    search_string = search.data['search']

    if search_string:
        if search.data['select'] == 'Ship':
            qry = db_session.query(Pirate, Ship).filter(
                Ship.id==Pirate.ship_id).filter(
                    Ship.name.contains(search_string))
            results = [item[0] for item in qry.all()]
        elif search.data['select'] == 'Pirate':
            qry = db_session.query(Pirate).filter(
                Pirate.name.contains(search_string))
            results = qry.all()
        elif search.data['select'] == 'Port':
            qry = db_session.query(Pirate, Port).filter(
                Port.id==Pirate.port_id).filter(
                    Port.name.contains(search_string))
            results = [item[0] for item in qry.all()]     
        else:
            qry = db_session.query(Pirate)
            results = qry.all()
    else:
        qry = db_session.query(Pirate)
        results = qry.all()

    if not results:
        flash('No results found!')
        return redirect('/')
    else:
        # display results
        table = Results(results)
        table.border = True
        return render_template('results.html', table=table)

@app.route('/new_pirate', methods=['GET', 'POST'])
def new_pirate():
    """
    Add a new pirates
    """
    form = PirateForm(request.form)

    if request.method == 'POST' and form.validate():
        # save the pirate
        pirate = Pirate()
        save_changes(pirate, form, new=True)
        flash('Pirate created successfully!')
        return redirect('/')

    return render_template('new_pirate.html', form=form)

def save_changes(pirate, form, new=False):
    """
    Save the changes to the database
    """
    # Get data from form and assign it to the correct attributes
    # of the SQLAlchemy table object
    ship = Ship()
    ship.name = form.ship.data
    
    port = Port()
    port.name = form.port.data

    pirate.ship = ship
    pirate.port = port
    pirate.name = form.name.data
    pirate.good_or_evil = form.good_or_evil.data

    if new:
        # Add the new album to the database
        db_session.add(pirate)

    # commit the data to the database
    db_session.commit()

@app.route('/item/<int:id>', methods=['GET', 'POST'])
def edit(id):
    qry = db_session.query(Pirate).filter(
                Pirate.id==id)
    pirate = qry.first()

    if pirate:
        form = PirateForm(formdata=request.form, obj=pirate)
        if request.method == 'POST' and form.validate():
            # save edits
            save_changes(pirate, form)
            flash('Pirate updated successfully!')
            return redirect('/')
        return render_template('edit_pirate.html', form=form)
    else:
        return 'Error loading #{id}'.format(id=id)

@app.route('/delete/<int:id>', methods=['GET', 'POST'])
def delete(id):
	"""
	Delete the item in the database that matches the specified 
	id in the url
	"""
	qry = db_session.query(Pirate).filter(
		Pirate.id==id)
	pirate = qry.first()
	
	if pirate:
		form = DeletePirateForm(formdata=request.form, obj=pirate)
		if request.method == 'POST' and form.validate():
			db_session.delete(pirate)
			db_session.commit()
			
			flash('Pirate deleted successfully!')
			return redirect('/')
			
		return render_template('delete_pirate.html', form=form)
	else:
		'Error deleting #{id}'.format(id=id)

if __name__ == '__main__':
    import os
    app.run(debug=True)
