#version 440 core

in vec4 fragColour;
out vec4 colour;

void main(void)
{
	colour = fragColour;
}