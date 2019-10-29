import epicbox

epicbox.configure(
    profiles=[
        epicbox.Profile('python', 'python:3.6.9-alpine3.10')
    ]
)


files = [{'name': 'main.py', 'content': b'print(42)'}]


limits = {'cputime': 1, 'memory': 64}


epicbox.run('python', 'python3 main.py', files=files, limits=limits)