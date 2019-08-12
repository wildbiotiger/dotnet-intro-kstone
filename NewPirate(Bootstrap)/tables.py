from flask_table import Table, Col, LinkCol

class Results(Table):
	classes = ['table', 'table-bordered', 'table-striped']
	id = Col('Id', show=False)    
	name = Col('Names')
	ship = Col('Ship')  
	port = Col('Port')
	good_or_evil = Col('Side')
	edit = LinkCol('Edit', 'edit', url_kwargs=dict(id='id'))
	delete = LinkCol('Delete', 'delete', url_kwargs=dict(id='id'))
