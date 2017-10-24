#version 440 core

layout(location = 0) in vec3 col;
layout(location = 1) in vec4 position;
out vs_colour;

void main(void)
{
	gl_Position = position;
	vs_colour = col;
}